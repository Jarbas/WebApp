using Rafitec.Cloud.Utils.ClassExtensions;
using Rafitec.Cloud.Utils.Anotacao;
using System.ComponentModel.DataAnnotations;

namespace Rafitec.Cloud.Utils.Enums
{
    public enum EntidadePessoa
    {
        [EnumDescricao("Fisíca")]
        Fisica,
        [EnumDescricao("Jurídica")]
        Juridica,
        [EnumDescricao(" - "), IsDefaultEnumValue]
        None
    }

    public enum Status
    {
        [EnumDescricao("Ativo")]
        Ativo,
        [EnumDescricao("Inativo")]
        Inativo,
        [EnumDescricao(" - "), IsDefaultEnumValue]
        None
    }

    public enum Frete
    {
        [EnumDescricao("Cif")]
        Cif,
        [EnumDescricao("Fob")]
        Fob,
        [EnumDescricao(" - "), IsDefaultEnumValue]
        None
    }

    public enum StatusPedido
    {

        [EnumDescricao("Aberto")]
        Aberto,
        [EnumDescricao("Análise")]
        Analise,
        [EnumDescricao("Aprovado")]
        Aprovado,
        [EnumDescricao("Pedido")]
        Pedido,
        [EnumDescricao("Cancelado")]
        Cancelado,
        [EnumDescricao("Reprovado")]
        Reprovado,
        [EnumDescricao("Perdido")]
        Perdido,
        [EnumDescricao("Revisado")]
        Revisado,
        [EnumDescricao("Faturado")]
        Faturado,
        [EnumDescricao(" - "), IsDefaultEnumValue]
        None
    }
    

    public enum TipoCliente
    {
        [EnumDescricao(" - "), IsDefaultEnumValue]
        None,
        [EnumDescricao("Anual")]
        Anual,
        [EnumDescricao("Mensalista")]
        Mensalista,
        [EnumDescricao("Safrista")]
        Safrista,
        [EnumDescricao("Sazonal")]
        Sazonal
    }

    public enum EntidadeSituacao
    {
        [EnumDescricao(" - "), IsDefaultEnumValue]
        None,
        [EnumDescricao("Ativo")]
        Ativo,
        [EnumDescricao("Inativo")]
        Inativo,
        [EnumDescricao("Potencial")]
        Potencial,
        [EnumDescricao("Baixado")]
        Baixado 
    }

    public enum SimNao
    {
        Sim, Nao
    }

    public enum FormaPagamento
    {        
        [Display(Name = "Não Definido"), IsDefaultEnumValue]
        None,
        [Display(Name = "À Vista")]
        AVista,
        [Display(Name = "À prazo")]
        APrazo,
        [Display(Name = "Antecipado")]
        Antecipado
    }

    public enum UnidadeNegocio
    {
        [EnumDescricao(" - "), IsDefaultEnumValue]
        None = 0,
        [EnumDescricao("Sacaria")]
        Sacaria = 1,
        [EnumDescricao("Big Bag")]
        Bag = 2,
        [EnumDescricao("Aviario")]
        Aviario = 3,
        [EnumDescricao("Tecidos Especial")]
        TecidoEspecial = 4,
        [EnumDescricao("Polietileno")]
        Polietileno = 5,
        [EnumDescricao("Diversos/Outros")]
        DiversosOutros = 99
    }

    public enum EntidadeTipo
    {
        [EnumDescricao("Empresa")]
        Empresa,
        [EnumDescricao("Cliente")]
        Cliente,
        [EnumDescricao("Fornecedor")]
        Fornecedor,
        [EnumDescricao("Representante")]
        Representante,
        [EnumDescricao(" - "), IsDefaultEnumValue]
        None
    }

    public enum DisponibilidadeVenda
    {
        [EnumDescricao("Disponível")]
        Disponivel,
        [EnumDescricao("Indisponível")]
        Indisponivel
    }

    public enum GrupoOsTi
    {
        [EnumDescricao(" - "), IsDefaultEnumValue]
        NAO_EXISTE,
        [EnumDescricao("SOFTWARE")]
        SOFTWARE,
        [EnumDescricao("HARDWARE")]
        HARDWARE
    }

    public enum AvaliacaoOsTi
    {
        [EnumDescricao(" - "), IsDefaultEnumValue]
        NAO_EXISTE,
        [EnumDescricao("ÓTIMO")]
        OTIMO,
        [EnumDescricao("BOM")]
        BOM,
        [EnumDescricao("REGULAR")]
        REGULAR,
        [EnumDescricao("RUIM")]
        RUIM,
        [EnumDescricao("REVISAR")]
        REVISAR,
        [EnumDescricao("CANCELADO")]
        CANCELADO,
        [EnumDescricao("OK")]
        OK
    }


}
