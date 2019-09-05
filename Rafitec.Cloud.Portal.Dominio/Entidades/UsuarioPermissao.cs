using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rafitec.Cloud.Portal.Dominio.Entidades
{
    [Table("USUARIOS_PERMISSOES")]
    public class UsuarioPermissao
    {
        [Key, Column("ID_PERMISSAO")]
        public int idPermissao { get; set; }
        [Column("CONTROLLER_NAME")]
        public string ControllerName { get; set; }
        [Column("ACTION_NAME")]
        public string ActionName { get; set; }
        [Column("ID_USUARIO")]
        public int idUsuario { get; set; }
        [ForeignKey("idUsuario")]
        public Usuario Usuario { get; set; }

    }
}
