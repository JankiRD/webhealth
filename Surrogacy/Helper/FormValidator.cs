using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Surrogacy.Entity;
using static Surrogacy.Entity.FormData;
using static Surrogacy.Helper.StringHelper;

namespace Surrogacy.Helper
{
    public class FormValidator
    {

        public static bool validateForm(List<FormData> lsFormData, out string outputMessage)
        {
            bool boolResponse = true;
            outputMessage = "<ul>";

            foreach (FormData formData in lsFormData)
            {
                string DisplayText = formData.DisplayText;
                string Name = formData.Name;
                string Value = formData.Value;
                string CompareWith = formData.CompareWith;
                FormInputType formInputType = formData.inputType;
                bool isRequired = formData.IsRequired;
                bool? isComparision = formData.IsComparision;

                if (isRequired && (string.IsNullOrEmpty(Value) || Value.Trim().Length == 0))
                {
                    outputMessage = outputMessage + "<li> " + DisplayText + " is required. </li>";
                    boolResponse = false;
                    continue;
                }



                if (!isRequired && string.IsNullOrEmpty(Value))
                {
                    continue;
                }

                switch (formData.inputType)
                {
                    case FormInputType.TextNotEmpty:
                        {
                            if (!StringHelper.IsEmpty(Value))
                            {
                                outputMessage = outputMessage + FormValidator.getErrorMessage(DisplayText);
                                boolResponse = false;
                            }
                            break;
                        }
                    case FormInputType.NumericOrZero:
                        {
                            if (!StringHelper.IsNumericOrZero(Value))
                            {
                                outputMessage = outputMessage + FormValidator.getErrorMessage(DisplayText);
                                boolResponse = false;
                            }
                            break;
                        }
                    case FormInputType.NameWithSpace:
                        {
                            if (!StringHelper.IsValidNameWithSpace(Value))
                            {
                                outputMessage = outputMessage + FormValidator.getErrorMessage(DisplayText);
                                boolResponse = false;
                            }
                            break;
                        }
                    case FormInputType.MobileNumber:
                        {
                            if (!StringHelper.IsNumeric(Value) || Value.Length != 10)
                            {
                                outputMessage = outputMessage + FormValidator.getErrorMessage(DisplayText);
                                boolResponse = false;
                            }
                        }
                        break;
                    case FormInputType.PhoneNumber:
                        {
                            if (!StringHelper.IsNumeric(Value) || Value.Length != 10)
                            {
                                outputMessage = outputMessage + FormValidator.getErrorMessage(DisplayText);
                                boolResponse = false;
                            }
                        }
                        break;
                    case FormInputType.Email:
                        {
                            if (!StringHelper.IsValidEmail(Value) && !string.IsNullOrEmpty(Value))
                            {
                                outputMessage = outputMessage + FormValidator.getErrorMessage(DisplayText);
                                boolResponse = false;
                            }
                        }
                        break;
                    case FormInputType.State:
                        {
                            if (!StringHelper.IsNumericNotZero(Value))
                            {
                                outputMessage = outputMessage + FormValidator.getErrorMessage(DisplayText);
                                boolResponse = false;
                            }
                        }
                        break;
                    case FormInputType.City:
                        {
                            if (!StringHelper.IsNumericNotZero(Value))
                            {
                                outputMessage = outputMessage + FormValidator.getErrorMessage(DisplayText);
                                boolResponse = false;
                            }
                        }
                        break;
                    case FormInputType.Age:
                        {
                            if (!StringHelper.IsNumericNotZero(Value) || !(Convert.ToInt32(Value) > 0 && Convert.ToInt32(Value) < 130))
                            {
                                outputMessage = outputMessage + FormValidator.getErrorMessage(DisplayText);
                                boolResponse = false;
                            }
                        }
                        break;
                    case FormInputType.Date:
                        {
                            if (!StringHelper.IsValidDataType(DataType.DATE, Value))
                            {
                                outputMessage = outputMessage + FormValidator.getErrorMessage(DisplayText);
                                boolResponse = false;
                            }
                        }
                        break;
                    case FormInputType.Height:
                        {
                            if (!StringHelper.IsValidDataType(DataType.DECIMAL, Value) || Convert.ToDecimal(Value) > 210)
                            {
                                outputMessage = outputMessage + FormValidator.getErrorMessage(DisplayText);
                                boolResponse = false;
                            }
                        }
                        break;
                    case FormInputType.Weight:
                        {
                            if (!StringHelper.IsValidDataType(DataType.DECIMAL, Value) || Convert.ToDecimal(Value) > 300)
                            {
                                outputMessage = outputMessage + FormValidator.getErrorMessage(DisplayText);
                                boolResponse = false;
                            }
                        }
                        break;
                    case FormInputType.DropDownListValue:
                        {
                            if (!StringHelper.IsNumericNotZero(Value))
                            {
                                outputMessage = outputMessage + FormValidator.getErrorMessage(DisplayText);
                                boolResponse = false;
                            }
                        }
                        break;
                    default:
                        break;
                }

                if ((isComparision ?? false) && Value != CompareWith)
                {
                    outputMessage = outputMessage + FormValidator.getErrorMessage(DisplayText);
                    boolResponse = false;
                }
            }
            outputMessage = outputMessage + "</ul>";
            return boolResponse;
        }

        private static string getErrorMessage(string displayText)
        {
            return "<li> " + displayText + " is invalid. </li>";
        }
    }
}