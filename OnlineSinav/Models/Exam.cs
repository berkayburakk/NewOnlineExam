﻿using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineSinav.Models
{
    public class Exam
    {
        public virtual int id { get; set; }
        public virtual DateTime examDate { get; set; }
        public virtual DateTime examStart { get; set; }
        public virtual DateTime examEnd { get; set; }
        public virtual Department Department { get; set; }
        public virtual Users teacher { get; set; }
        public virtual string ExamName { get; set; }
        public virtual string ExamDuration { get; set; }

        public virtual IList<Questions> ExamQuestions { get; set; }
        public virtual IList<Users> ExamStudents { get; set; }

        public Exam()
        {
            ExamQuestions = new List<Questions>();
            ExamStudents = new List<Users>();
        }
    }

    public class ExamMap : ClassMapping<Exam>
    {

        public ExamMap()
        {
            Schema("onlineexam");
            Lazy(true);
            Id(x => x.id, map => { map.Column("id"); map.Generator(Generators.Identity); });
            Property(x => x.ExamName, map => { map.Column("exam_name"); map.NotNullable(true); });
            Property(x => x.examDate, map => { map.Column("exam_date"); map.NotNullable(true); });
            Property(x => x.examStart, map => { map.Column("exam_start"); map.NotNullable(true); });
            Property(x => x.examEnd, map => { map.Column("exam_end"); map.NotNullable(true); });
            Property(x => x.ExamDuration, map => { map.Column("exam_duration"); map.NotNullable(true); });

            ManyToOne(x => x.Department, map => { map.Column("dept_id"); map.Cascade(Cascade.None); });
            ManyToOne(x => x.teacher, map => { map.Column("teacher_id"); map.Cascade(Cascade.None); });

            Bag(x => x.ExamQuestions, x => {
                x.Table("exam_quest");
                x.Key(k => k.Column("exam_id"));
            }, x => x.ManyToMany(k => k.Column("quest_id")));

            Bag(x => x.ExamStudents, x => {
                x.Table("exam_student");
                x.Key(k => k.Column("exam_id"));
            }, x => x.ManyToMany(k => k.Column("student_id")));
        }
    }
}