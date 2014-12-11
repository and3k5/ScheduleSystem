using System.ComponentModel.DataAnnotations;

public class Student : Person
{
    [Key]
    public int ID { get; set; }
	public virtual string CPR
	{
		get;
		set;
	}

}

