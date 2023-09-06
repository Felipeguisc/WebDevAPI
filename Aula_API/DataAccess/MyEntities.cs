using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("MyEntities")]
public class MyEntity
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
}

[Table("Funcionario")]
public class Funcionario
{
    [Key]
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Matricula { get; set; }
    public string Cpf { get; set; }
    public string Telefone { get; set; }
    public byte Grupo { get; set; }
    public string Senha { get; set; }
}

[Table("Cliente")]
public class Cliente
{
    [Key]
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public string Telefone { get; set; }
    public int CompraFiado { get; set; }
    public byte DiaFiado { get; set; }
    public string senha { get; set; }
}

[Table("Produto")]
public class Produto
{
    [Key]
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public byte[] Foto { get; set; } // Use byte[] for BLOB data
    public decimal ValorUnitario { get; set; }
}