using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Surrogacy.Entity;

namespace Surrogacy.Util
{
    #region Enum Properties

    public enum EntityState
    {
        View,
        Save,
        Edit,
        Delete,
        None
    }

    public enum MachineType
    {
        Desktop,
        Mobile,
        Tablet
    }

    public enum ContactType
    {
        Email,
        Phone,
        Fax
    }
    public enum ResponseType
    {
        Warning,
        Error,
        Information,
        Success
    }

    public enum InputType
    {
        UserName,
        Password,
        Text,
        Number
    }

    public enum DropDownControlType
    {
        Html,
        Asp
    }

    public enum DropDownControlFilterBy
    {
        Category,
        ParentCategory
    }

    public enum CustomFileType
    {
       IdProof,
       Pic,
       FamilyPic
    }

    #endregion Enum Properties    
}