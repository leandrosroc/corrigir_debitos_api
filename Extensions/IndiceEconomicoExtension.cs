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

using Indices.Enums;

namespace Indices.Extensions;
public static class IndiceEconomicoExtension
{
    public static string BuscarCodigoDoIndice(this IndiceEconomico indice)
    {
        switch (indice)
        {
            case IndiceEconomico.IGPM_FGV_Desde_06_1989:
                return "28655IGP-M";
            case IndiceEconomico.IGP_DI_FGV_Desde_02_1944:
                return "00190IGP-DI";
            case IndiceEconomico.INPC_IBGE_Desde_04_1979:
                return "00188INPC";
            case IndiceEconomico.IPCA_IBGE_Desde_01_1980:
                return "00433IPCA";
            case IndiceEconomico.IPCA_E_IBGE_Desde_01_1992:
                return "10764IPC-E";
            case IndiceEconomico.IPC_BRASIL_FGV_Desde_01_1990:
                return "00191IPC-BRASIL";
            case IndiceEconomico.IPC_SP_FIPE_Desde_11_1942:
                return "00193IPC-SP";
            default:
                throw new NotImplementedException("Índice não mapeado para código correspondente.");
        }
    }
}