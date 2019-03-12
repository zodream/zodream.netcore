using ZoDream.Util;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static ZoDream.Entity.Base_SysManage.EnumType;

namespace ZoDream.Entity.Base_SysManage
{
    /// <summary>
    /// ϵͳ��ɫ
    /// </summary>
    [Table("Base_SysRole")]
    public class Base_SysRole
    {

        /// <summary>
        /// ��������
        /// </summary>
        [Key]
        public String Id { get; set; }

        /// <summary>
        /// �߼���������ɫId
        /// </summary>
        public String RoleId { get; set; }

        /// <summary>
        /// ��ɫ��
        /// </summary>
        public String RoleName { get; set; }

        public RoleType? RoleType { get => RoleName?.ToEnum<RoleType>(); }
    }
}