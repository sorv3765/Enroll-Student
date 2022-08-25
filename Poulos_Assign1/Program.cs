/***********************************************************
*  CSCI 473/504          Assignment 1          Fall 2018   *
*                                                          *
*  Programmer: Yiannis Poulos                              *
*              Shaniel Omar Rivas Verdejo                  *
*                                                          *
*  Section:    1                                           *
*                                                          *
*  Date Due:   09/13/2018                                  *
*                                                          *
*  Purpose:    This program shows how we choose students   *
*              to enroll or drop a course                  *
*                                                          *
***********************************************************/

using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poulos_Assign1
{
    class Assign1 
    {
        enum Standing { Freshman, Sophomore, Junior, Senior, PostBacc };
        static List<Student> studentList = new List<Student>();
        List<Course> courseList = new List<Course>();

        class Student : IComparable<Object>
        {
            private readonly uint zID;
            private string firstName;
            private string lastName;
            private string major;
            private float gpa;
            private ushort credits;
            private Standing year;

            /********************************************************
            * public Student: Default Constructor for Student class *
            ********************************************************/
            public Student()
            {
                firstName = "";
                lastName = "";
                major = "";
                year = 0;
                gpa = 0;
                credits = 0;
            }

            /**********************************************************
            * public Student: Alternate Constructor for Student class *
            **********************************************************/
            public Student(uint newZID, string newfName, string newlName, string newMajor, Standing newYear, float newGPA)
            {
                if (zID >= 1000000)
                {
                    zID = newZID = zID;
                    FirstName = newfName;
                    LastName = newlName;
                    Major = newMajor;
                    Year = newYear;
                    Gpa = newGPA;
                }
                zID = newZID;
                FirstName = newfName;
                LastName = newlName;
                Major = newMajor;
                Year = newYear;
                Gpa = newGPA;
            }

            /***********************************************************
            * int CompareTo(): allow for student objects to be sorted  *
            ***********************************************************/
            public int CompareTo(object alpha)
            {
                if (alpha == null)
                    return -1;

                Student rightOp = (Student)alpha;  //create a typecast for rightOp

                if (rightOp != null)
                {
                    if (zID < rightOp.zID)
                        return -1;

                    else if (zID == rightOp.zID)
                        return 0;

                    else if (zID > rightOp.zID)
                        return 1;
                }


                return -1;
            }



            /******************************************************************
            * int Enroll(): Check if student can be enrolled in given course  *
            ******************************************************************/
            public int Enroll(Course newCourse)
            {
                /*           
                           if (newCourse.NumEnrolled = newCourse.MaxEnroll)
                               return;

                           else if

                           else if (credits + newCourse.NumCredits > 18)
                               return;
               */
                newCourse.StudentIDs.Add(zID);
                    return 0;
            }

            /**************************************************
            * int Drop(): Remove student from a given course  *
            **************************************************/
            public int Drop(Course newCourse)
            {
                newCourse.StudentIDs.Remove(zID);
                    return 0;
            }

            /*************************************************************
            * string ToString(): Format student attributes into a string *
            *************************************************************/
            public override string ToString()
            {
                return "Z" + zID + " -- " + lastName + ", " + firstName + " [" + year + "] " + "<" + major + ">" + "| " + gpa + " |";
            }
            /*
            int IComparable<Student>.CompareTo(Student other)
            {
                throw new NotImplementedException();
            }*/

            /*public void readStudent(StreamReader sr)
            {
                Assign1 a1 = new Assign1();
                string line = sr.ReadLine();

                string[] arrOfStudents = line.Split(',');
                Student studentInfo = new Student(UInt32.Parse(arrOfStudents[0]), arrOfStudents[1], arrOfStudents[2],
                                                  arrOfStudents[3], (Standing)Int32.Parse(arrOfStudents[4]), float.Parse(arrOfStudents[5]));

                a1.studentList.Add(studentInfo);
            }*/

            public uint Zid
            {
                get { return zID; }
            }

            //Set public properties for first name
            public string FirstName
            {
                get { return firstName; }
                set { firstName = value; }
            }

            //Set public properties for last name
            public string LastName
            {
                get { return lastName; }
                set { lastName = value; }
            }

            //Set public properties for major
            public string Major
            {
                get { return major; }
                set { major = value; }
            }

            //Set public properties for GPA
            public float Gpa
            {
                get { return gpa; }

                set
                {
                    if (value >= 0 && value <= 4)
                        gpa = value;
                }
            }

            //Set public properties for class standing
            public Standing Year
            {
                get { return year; }
                set { year = value; }
            }

            //Set public properties for credits
            public ushort Credits
            {
                get { return credits; }

                set
                {
                    if (value >= 0 && value <= 18)
                        credits = value;
                }
            }
        }

        class Course
        {
            private string deptCode;
            private uint courseNum;
            private string sectNum;
            private ushort numCredits;
            private List<uint> studentIDs;
            private ushort numEnrolled;
            private ushort maxEnroll;
            private int numErolled;

            /******************************************************
            * public Course: Default Constructor for Course class *
            ******************************************************/
            public Course()
            {
                deptCode = "";
                courseNum = 0;
                sectNum = "";
                numCredits = 0;
                studentIDs = null;
                numEnrolled = 0;
                maxEnroll = 0;
            }

            /******************************************************
            * int CompareTo(): Print roster for a given course   *
            ******************************************************/
            public int CompareTo(object alpha)
            {
                if (alpha == null)
                    return -1;

                return 0;
            }

            /********************************************************
            * void PrintRoster(): Print roster for a given course   *
            ********************************************************/
            public void PrintRoster()
            {
                Console.WriteLine("Course: " + deptCode + " " + courseNum + "-" + sectNum + " (" + numEnrolled + "/" + maxEnroll);
                Console.WriteLine("-----------------------------------------------------");

            }

            /**********************************************************
            * string ToString: Format course attributes into a string *
            **********************************************************/
            public override string ToString()
            {
                return deptCode + " " + courseNum + "-" + sectNum + " (" + numEnrolled + "/" + maxEnroll + ")";
            }

            //Set public properties for class credits
            public int NumCredits
            {
                get { return numCredits; }
            }

            //Set public properties for list of Student IDs
            public List<uint> StudentIDs
            {
                get { return studentIDs; }
                set { studentIDs = value; }
            }

            //Set public properties for number of enrolled students
            public int NumEnrolled
            {
                get { return numEnrolled; }
            }

            //Set public properties for maximum enrollment capacity
            public int MaxEnroll
            {
                get { return maxEnroll; }
            }

         
        }
        static void Main(string[] args)
        {
            int studentCount = 0;
            int courseCount = 0;
            string choice = "";
            string line;
            string inputMajor = "";
            string inputYear = "";
            string inputCourse = "";
            uint inputZID = 0;
           // Student s = new Student();

            //Read from Students.txt for student info
            try
            {
                using (StreamReader inFile = new StreamReader(@"Students.txt"))
                {
                    line = inFile.ReadLine();

                    //While not the end of the file...
                    while (line != null)
                    {
                        
                        List<string> stringList = line.Split(',').ToList();
                        uint zid = uint.Parse(stringList[0]);             //Convert uint to string 
                        String firstName = stringList[1];
                        String lastName = stringList[2];
                        String major = stringList[3];
                        int year = int.Parse(stringList[4]);            //convert int to string
                        float gpa = float.Parse(stringList[5]);         //convert float to string
                        //Console.WriteLine((Standing)year);
                       
                        Student s = new Student(zid, firstName, lastName, major, (Standing)year, gpa);
                        //Console.WriteLine(s.ToString());
                        studentList.Add(s);
                        studentCount++;
                        line = inFile.ReadLine();   //keep reading
                    }
                }
            }

            //If file failed to open, print exception
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
                Environment.Exit(1);
            }

            //Read from Courses.txt for course info
            try
            {
                using (StreamReader inFile = new StreamReader(@"Courses.txt"))
                {
                    line = inFile.ReadLine();

                    //While not the end of the file
                    while (line != null)
                    {
                        // Console.WriteLine(line);
                        line = inFile.ReadLine();   //keep reading

                        courseCount++;
                    }
                }
            }

            //If file failed to open, print exception
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
                Environment.Exit(1);
            }

            //s.readStudent(inFile);

            Console.WriteLine("We have " + studentCount + " students and " + courseCount + " courses.");
            Console.WriteLine();

            //Main loop for interface
            do
            {
                Console.WriteLine("Please choose from the following options: \n");

                Console.WriteLine("1. Print Student List <All>");
                Console.WriteLine("2. Print Student List <Major>");
                Console.WriteLine("3. Print Student List <Academic Year>");
                Console.WriteLine("4. Print Course List");
                Console.WriteLine("5. Print Course Roster");
                Console.WriteLine("6. Enroll Student");
                Console.WriteLine("7. Drop Student");
                Console.WriteLine("8. Quit Application");
                Console.WriteLine();

                choice = Console.ReadLine();
                
                //Check entered option...
                if (choice.Equals("1"))
                {
                    Console.WriteLine("\nStudent List <All Students>");
                    Console.WriteLine("-------------------------------------------------");

                    studentList.Sort();
                    
                    for (int i = 0; i < studentList.Count; i++)
                    {
                        Console.WriteLine(studentList[i].ToString());
                    }
                    Console.WriteLine();
                }

                else if (choice.Equals("2"))
                {
                    Console.Write("Which major would you like to see printed?: ");

                    inputMajor = Console.ReadLine();

                    Console.WriteLine("\nStudent List <Major>");
                    Console.WriteLine("-------------------------------------------------");
                    Console.WriteLine();
                }

                else if (choice.Equals("3"))
                {
                    Console.WriteLine("Which academic year would you like to see printed?");
                    Console.Write("<Freshman, Sophomore, Junior, Senior, PostBacc>: ");

                    inputYear = Console.ReadLine();

                    Console.WriteLine("\nStudent List <Academic Year>");
                    Console.WriteLine("-------------------------------------------------");
                    Console.WriteLine();
                }

                else if (choice.Equals("4"))
                {
                    Console.WriteLine("\nCourse List <All Courses>");
                    Console.WriteLine("-------------------------------------------------");
                    Console.WriteLine();
                }

                else if (choice.Equals("5"))
                {
                    Console.WriteLine("\nWhich course roster would you like to see printed?");
                    Console.Write("<DEPT COURESE_NUM-SECTION_NUM>: ");

                    inputCourse = Console.ReadLine();

                    Console.WriteLine("\nCourse: " + inputCourse + "<" + ">");
                    Console.WriteLine("-------------------------------------------------");
                    Console.WriteLine();
                }

                else if (choice.Equals("6"))
                {
                    Console.WriteLine("\nPlease enter the Z-ID (omitting the 'Z' character)");
                    Console.Write("of the student you wish to enroll into a course: ");

                    inputZID = Convert.ToUInt32(Console.ReadLine());

                    Console.WriteLine("Which course will this student be enrolled into?");
                    Console.Write("<DEPT COURESE_NUM-SECTION_NUM>: ");

                    inputCourse = Console.ReadLine();

                    Console.WriteLine("\nz" + inputZID + "has been successfully added to " + inputCourse);
                    Console.WriteLine();
                }

                else if (choice.Equals("7"))
                {
                    Console.WriteLine("\nPlease enter the Z-ID (omitting the 'Z' character)");
                    Console.Write("of the student you wish to drop from a course: ");

                    inputZID = Convert.ToUInt32(Console.ReadLine());

                    Console.WriteLine("Which course will this student be dropped from?");
                    Console.Write("<DEPT COURESE_NUM-SECTION_NUM>: ");

                    inputCourse = Console.ReadLine();

                    Console.WriteLine("\nz" + inputZID + "has been successfully dropped from " + inputCourse);
                    Console.WriteLine();
                }

                else
                {
                    if (!choice.Equals("8"))
                    {
                        Console.WriteLine("\nInvalid Option Choice\n");
                    }
                }
            }

            while (!choice.Equals("8"));
        }
    }
}