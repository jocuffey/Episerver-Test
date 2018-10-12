using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using EPiServer.Core;
using EPiServer.SpecializedProperties;

namespace EpiserverTest.Business.Rendering
{
    /// <summary>
    /// Sets the maximum element count in a linkcollection, a content area - or any other type of collection.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class MaxElementsAttribute : ValidationAttribute, IMetadataAware
    {
        public int MaxCount { get; set; }

        public void OnMetadataCreated(ModelMetadata metadata)
        {
            //TODO: Use to disable editor drag and drop at a certain point.
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return null;
            }
            if (value is LinkItemCollection)
            {
                if ((value as LinkItemCollection).Count > MaxCount)
                {
                    return new ValidationResult("This field exceeds the maximum limit of " + MaxCount + " items");
                }
            }
            else if (value is ContentArea)
            {
                if ((value as ContentArea).Count > MaxCount)
                {
                    return new ValidationResult("This field exceeds the maximum limit of " + MaxCount + " items");
                }
            }

            return null;
        }

        public MaxElementsAttribute(int MaxElementsInList)
        {
            this.MaxCount = MaxElementsInList;
        }
    }
}