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

namespace CorrigirDebitos;

public class CorrigirDebitos
{
    public string? MesAno { get; set; }

    public IndiceEconomico Indice { get; set; }

    public IFormFile? ArquivoCSV { get; set; }
}
