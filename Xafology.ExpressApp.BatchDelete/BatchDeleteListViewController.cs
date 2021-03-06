﻿using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xafology.ExpressApp.SystemModule;
using Xafology.ExpressApp.Xpo;

namespace Xafology.ExpressApp.BatchDelete
{
    public class BatchDeleteListViewController : ViewController
    {
        private const string deleteFilteredCaption = "Delete Filtered";
        private const string deleteSelectedCaption = "Delete Selected";
        private const string showFilterXpoCaption = "Show Filter XPO";
        private const string showFilterSqlCaption = "Show Filter SQL";
        private const string purgeCaption = "Purge";

        private SingleChoiceAction batchDeleteAction;
        private ChoiceActionItem delFiltered;

        public BatchDeleteListViewController()
        {
            TargetViewType = ViewType.ListView;
            //TargetObjectType = typeof(IBatchDeletable);

            batchDeleteAction = new SingleChoiceAction(this, "BatchUpdateAction", DevExpress.Persistent.Base.PredefinedCategory.Edit);
            batchDeleteAction.Caption = "Batch";
            batchDeleteAction.ItemType = SingleChoiceActionItemType.ItemIsOperation;
            batchDeleteAction.Execute += batchDeleteAction_Execute;
            batchDeleteAction.ShowItemsOnClick = true;

            var delSelected = new ChoiceActionItem();
            delSelected.Caption = deleteSelectedCaption;
            batchDeleteAction.Items.Add(delSelected);

            delFiltered = new ChoiceActionItem();
            delFiltered.Caption = deleteFilteredCaption;
            batchDeleteAction.Items.Add(delFiltered);

            var showFilterXpoChoice = new ChoiceActionItem();
            showFilterXpoChoice.Caption = showFilterXpoCaption;
            batchDeleteAction.Items.Add(showFilterXpoChoice);

            var showFilterSqlChoice = new ChoiceActionItem();
            showFilterSqlChoice.Caption = showFilterSqlCaption;
            batchDeleteAction.Items.Add(showFilterSqlChoice);

            //var purgeChoice = new ChoiceActionItem();
            //purgeChoice.Caption = purgeCaption;
            //batchDeleteAction.Items.Add(purgeChoice);
        }

        private bool IsTargetObject
        {
            get
            {

                var attr = View.ObjectTypeInfo.FindAttribute<BatchDeleteAttribute>();

                if (attr == null || attr.IsVisible == false)
                    return false;
                return true;
            }
        }

        protected override void OnActivated()
        {
            base.OnActivated();
            if (IsTargetObject)
                this.Active.SetItemValue("Active", true);
            else
                this.Active.SetItemValue("Active", false);
            //View.ControlsCreated += View_ControlsCreated;
        }

        protected override void OnDeactivated()
        {
            base.OnDeactivated();
            //View.ControlsCreated -= View_ControlsCreated;
        }

        public bool DeleteFilteredChoiceEnabled
        {
            get { return delFiltered.Active["Enabled"];  }
            set { delFiltered.Active.SetItemValue("Enabled", value); }
        }

        private void batchDeleteAction_Execute(object sender, SingleChoiceActionExecuteEventArgs e)
        {
            var objSpace = (XPObjectSpace)Application.CreateObjectSpace();
            var currentTypeInfo = ((ObjectView)View).ObjectTypeInfo;
            var currentType = currentTypeInfo.Type;
            XPClassInfo classInfo = objSpace.Session.GetClassInfo(currentType);
            CriteriaOperator criteria = ActiveFilterEnabled ? ActiveFilterCriteria : null;

            switch (e.SelectedChoiceActionItem.Caption)
            {
                case deleteFilteredCaption:
                    new GenericMessageBox("This will delete all objects filtered in the current view. Do you wish to continue?",
                        "Confirm",
                        (sender1, svp1) => DeleteObjects(objSpace, criteria, classInfo),
                        (sender1, svp1) => { return; });
                    break;
                case deleteSelectedCaption:
                    new GenericMessageBox("This will delete all objects selected in the current view. Do you wish to continue?",
                                     "Confirm",
                                     (sender1, svp1) =>
                                     {
                                         var objs = View.SelectedObjects;
                                         DeleteObjects(objSpace, objs, classInfo);
                                         return;
                                     },
                                     (sender1, svp1) => { return; });
                    break;
                case showFilterXpoCaption:
                    ShowFilterXpo();
                    break;
                case showFilterSqlCaption:
                    ShowFilterSql();
                    break;
                case purgeCaption:
                    objSpace.Session.PurgeDeletedObjects();
                    break;
            }
        }

        private void ShowFilterXpo()
        {
            CriteriaOperator criteria = ActiveFilterCriteria;

            new GenericMessageBox(criteria.ToString(),
                        "Filter Criteria XPO Text");
        }

        private void ShowFilterSql()
        {
            CriteriaOperator criteria = ActiveFilterCriteria;
            var sqlCriteria = CriteriaToWhereClauseHelper.GetMsSqlWhere(XpoCriteriaFixer.Fix(criteria));
            new GenericMessageBox(sqlCriteria,
                        "Filter Criteria SQL Text");
        }

        private void DeleteObjects(XPObjectSpace objSpace, IList objs, XPClassInfo classInfo)
        {
            var inOp = new InOperator(
                objSpace.GetKeyPropertyName(classInfo.ClassType),
                objs);

            var deleter = new BatchDeleter(objSpace);
            deleter.Delete(classInfo, inOp);
        }

        private void DeleteObjects(XPObjectSpace objSpace, CriteriaOperator criteria, XPClassInfo classInfo)
        {
            var deleter = new BatchDeleter(objSpace);
            deleter.Delete(classInfo, criteria);
        }
        
        public virtual CriteriaOperator ActiveFilterCriteria { get { return null; } }
        public virtual bool ActiveFilterEnabled { get { return false; } }
    }
}
