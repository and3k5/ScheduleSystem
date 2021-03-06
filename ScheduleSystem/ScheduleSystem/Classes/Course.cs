﻿using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

public class Course
{
    [Key]
    public int ID { get; set; }
    private void Init()
    {
        Lectures = new Collection<Lecture>();
        Students = new Collection<Student>();
        StartDate = DateTime.Now;
        EndDate = DateTime.Now;
    }
    public Course()
    {
        Init();
    }
    public Course(string name)
    {
        Init();
        Name = name;
    }
	public virtual Collection<Lecture> Lectures
	{
		get;
		set;
	}

	public virtual Collection<Student> Students
	{
		get;
		set;
	}

	public virtual string Name
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
}

