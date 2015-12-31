﻿using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using DevExpress.Data.Filtering;
using DevExpress.Xpo.Metadata;
namespace Xafology.ExpressApp.Xpo.Import.Parameters
{
    public class HeadFieldMaps : XPCollection<HeaderToFieldMap>
    {
        public HeadFieldMaps(Session session, object theOwner, DevExpress.Xpo.Metadata.XPMemberInfo refProperty)
            : base(session, theOwner, refProperty)
        {
            
        }
        public HeadFieldMaps()
        {
            
        }
        public HeadFieldMaps(DevExpress.Data.Filtering.CriteriaOperator theCriteria, params SortProperty[] sortProperties)
            : base(theCriteria, sortProperties)
        {
            
        }
        public HeadFieldMaps(Session session)
            : base(session)
        {
            
        }
        public HeadFieldMaps(Session session, DevExpress.Data.Filtering.CriteriaOperator theCriteria, params SortProperty[] sortProperties)
            : base(session, theCriteria, sortProperties)
        {
            
        }
        public HeadFieldMaps(Session session, bool loadingEnabled)
            : base(session, loadingEnabled)
        {
            
        }
        public HeadFieldMaps(Session session, System.Collections.IEnumerable originalCollection, DevExpress.Data.Filtering.CriteriaOperator copyFilter, bool caseSensitive)
            : base(session, originalCollection, copyFilter, caseSensitive)
        {
            
        }
        public HeadFieldMaps(Session session, System.Collections.IEnumerable originalCollection, DevExpress.Data.Filtering.CriteriaOperator copyFilter)
            : base(session, originalCollection, copyFilter)
        {
            
        }
        public HeadFieldMaps(Session session, System.Collections.IEnumerable originalCollection)
            : base(session, originalCollection)
        {
            
        }
        public HeadFieldMaps(Session session, XPBaseCollection originalCollection, DevExpress.Data.Filtering.CriteriaOperator copyFilter, bool caseSensitive)
            : base(session, originalCollection, copyFilter, caseSensitive)
        {
            
        }
        public HeadFieldMaps(Session session, XPBaseCollection originalCollection, DevExpress.Data.Filtering.CriteriaOperator copyFilter)
            : base(session, originalCollection, copyFilter)
        {
            
        }
        public HeadFieldMaps(XPBaseCollection originalCollection, DevExpress.Data.Filtering.CriteriaOperator filter)
            : base(originalCollection, filter)
        {
            
        }
        public HeadFieldMaps(XPBaseCollection originalCollection, DevExpress.Data.Filtering.CriteriaOperator filter, bool caseSensitive)
            : base(originalCollection, filter, caseSensitive)
        {
            
        }
        public HeadFieldMaps(XPBaseCollection originalCollection)
            : base(originalCollection)
        {
            
        }
        public HeadFieldMaps(Session session, XPBaseCollection originalCollection)
            : base(session, originalCollection)
        {
            
        }
        public HeadFieldMaps(PersistentCriteriaEvaluationBehavior criteriaEvaluationBehavior, Session session, DevExpress.Data.Filtering.CriteriaOperator condition, bool selectDeleted)
            : base(criteriaEvaluationBehavior, session, condition, selectDeleted)
        {
            
        }
        public HeadFieldMaps(PersistentCriteriaEvaluationBehavior criteriaEvaluationBehavior, Session session, DevExpress.Data.Filtering.CriteriaOperator condition)
            : base(criteriaEvaluationBehavior, session, condition)
        {
            
        }
    }
}
