using lab9;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace lab7
{
    class Student : IDateAndCopy
    {
        private Person _person;
        private Education _education;
        private int _group;
        private ArrayList _testList;
        private ArrayList _examList;

        public Person Person
        {
            get => (Person)_person.DeepCopy();
            set
            {
                _person.Name = value.Name;
                _person.LastName = value.LastName;
                _person.BirthDay = value.BirthDay;
            }
        }
        
        public Education Education { get => _education; set => _education = value; }
        public int Group { get => _group; 
            set
            {
                if(value < 600 && value > 100)
                {
                    _group = value;
                }
                else
                throw new Exception("Значение должно быть в пределах от 100 до 600");
            }
        }
        public ArrayList ExamList { get => _examList; set => _examList = value; }

        public Student(Person person, Education education, int group)
        {
            _person = person;
            _education = education;
            Group = group;
            _examList = new ArrayList();
            _testList = new ArrayList();
        }
        public Student()
        {
            _person = new Person();
            _education = Education.Specialist;
            Group = 200;
            _examList = new ArrayList();
            _testList = new ArrayList();
        }
        public double Avg
        {
            get
            {
                if (this._examList.Count != 0)
                {
                    double avg = 0;
                    foreach (var element in _examList)
                    {
                        avg += ((Exam) element).Mark;
                    }
                    return avg / _examList.Count;
                }
                return 0;
            }
            set { }
        }

        public DateTime Date { get => _person.Date; set => _person.Date = value; }

        public bool this[Education education]
        {
            get
            {
                return _education == education;
            }
        }
        public void AddExams(params Exam[] exams)
        {
            _examList.AddRange(exams);
        }

        public void AddTests(params Test[] tests)
        {
            _testList.AddRange(tests);
        }
        public override string ToString()
        {
            string str = $"{_person}, {_education}, {_group} \n";

            for (int k = 0; k < _examList.Count; k++)
            {
                str += ((Exam)_examList[k]).ToString() + ", ";
            }
            for (int k = 0; k < _testList.Count; k++)
            {
                str += ((Test)_testList[k]).ToString() + ", ";
            }
            return str;
        }
        public virtual string ToShortString()
        {
            string info2 = $"{_person}, {_education}, {_group}, {Avg}";
            return info2;
        }

        public object DeepCopy()
        {
            Student copy = new Student(this._person, this._education, this._group);
            copy._testList = this._testList;
            copy._examList = this._examList;
            return copy;
        }
        public IEnumerable ExamsAndTests()
        {
            foreach(var item in _examList)
            {
                //метод создающий коллекцию, который ею и является
                yield return item;
            }

            foreach(var item in _testList)
            {
                yield return item;
            }
        }
        public IEnumerable ExamsBiggerThan(int mark)
        {
            foreach(var item in _examList)
            {
                if(((Exam)item).Mark >= mark)
                {
                    yield return item;
                }
            }
        }
    }
}
