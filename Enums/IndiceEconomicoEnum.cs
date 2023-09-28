/*
 * Copyright [2023] [Leandro Rocha]
 *
 * Licenciado sob a Licença Apache, Versão 2.0 (a "Licença");
 * você não pode usar este arquivo, exceto em conformidade com a Licença.
 * Você pode obter uma cópia da Licença em
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * A menos que exigido por lei aplicável ou acordado por escrito, o software
 * distribuído sob a Licença é distribuído "COMO ESTÁ", SEM GARANTIAS OU CONDIÇÕES DE QUALQUER
 * TIPO, expressas ou implícitas. Consulte a Licença para as permissões específicas
 * que regem as autorizações e limitações sob a Licença.
 */

using System.ComponentModel.DataAnnotations;

namespace Indices.Enums;

public enum IndiceEconomico
{
    [Display(Name = "IGP-M (FGV) - a partir de 06/1989")]
    IGPM_FGV_Desde_06_1989,

    [Display(Name = "IGP-DI (FGV) - a partir de 02/1944")]
    IGP_DI_FGV_Desde_02_1944,

    [Display(Name = "INPC (IBGE) - a partir de 04/1979")]
    INPC_IBGE_Desde_04_1979,

    [Display(Name = "IPCA (IBGE) - a partir de 01/1980")]
    IPCA_IBGE_Desde_01_1980,

    [Display(Name = "IPCA-E (IBGE) - a partir de 01/1992")]
    IPCA_E_IBGE_Desde_01_1992,

    [Display(Name = "IPC-BRASIL (FGV) - a partir de 01/1990")]
    IPC_BRASIL_FGV_Desde_01_1990,

    [Display(Name = "IPC-SP (FIPE) - a partir de 11/1942")]
    IPC_SP_FIPE_Desde_11_1942
}