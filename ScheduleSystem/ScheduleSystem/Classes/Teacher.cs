using System.ComponentModel.DataAnnotations;

public class Teacher : Person
{
    [Key]
    public int ID { get; set; }
	public virtual string Skills
	{
		get;
		set;
	}

}

