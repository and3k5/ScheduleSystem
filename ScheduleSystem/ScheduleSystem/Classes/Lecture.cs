using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

public class Lecture
{
    [Key]
    public int ID { get; set; }
    public void init()
    {
        Teachers = new Collection<Teacher>();
    }

    public Lecture()
    {
        init();
    }

    public Lecture(string name)
    {
        init();
        Name = name;
    }

	public virtual Collection<Teacher> Teachers
	{
		get;
		set;
	}

	public virtual DateTime StartDate
	{
		get;
		set;
	}

	public virtual DateTime EndDate
	{
		get;
		set;
	}

	public virtual string Name
	{
		get;
		set;
	}
}

