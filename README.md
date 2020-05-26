# DM 103347: VennDiagram

### PROJECT MEMBERS
StdID | Name
------------ | -------------
**63646** | **Taha Khan** 
62381 | Hamza Raza 
61880 | Umair Mehdi
62371 | Anas
63578 | Hasnain Tariq

## Project Description 

Venn diagrams are great for illustrating the relationship between two or three groups, you can easily see the commonalities and differences.

We are Working on Ven Diagram which has multiple functions but two functions are general  one is Union and Second is Intersection. First we were user input equation and then by clicking on Ven Diagram it will ploted the Ven Diagram of that equation.

The Venn diagram of librarians and technologists together clearly defines values and cultures that are unique and individual to each profession, yet it also has a solid center section of overlapping values and cultures that provide a solid common ground for cooperation, collaboration, and convergence. It is these areas that form the core opportunities for bringing professions together, and from which inroads can be made to further expand a common culture among information professionals.

Information
This is the obvious overlapping value, but it is the foundation upon which all these values (shared or separate) are formed. Libraries and technology organizations are information-based support structures designed to relate people to information. They are workflow-agnostic, having application across the institution, and as noted previously, they themselves are now joined together directly with the rise of electronic library services. They are also increasingly dealing with broadening definitions of information. At one time, information (collected by libraries and technologists) was principally print-based. Now multimedia materials are prevalent and reshaping the boundaries of what may be considered a library collection, or what types of data may be stored in a database. In reality, there should be no boundaries when it comes to information that may be relevant for libraries or technology organizations to pursue, capture, and make available. The future will require both professions to work very closely together to deliver these information systems to users.

## Discrete Math Concepts Used 
In this project we have to  plote vennDiagram By using these functions union and intersection.
we were solve the equations and drawn the ven diagram of each quation.

### Example 1: 

    class Union
    {
        // Union Method 
        int[] Unions(int[] Equations1, int[] Equations2, int LA1, int LA2)
        {
            int[] result = new int[LA1 + LA2];
            int index = 0, i = 0, j = 0;
            while (i < LA1 && j < LA2)
            {
                if (Equations1[i] < Equations2[j])
                {
                    if (Equations1[i] != 0)
                    {
                        result[index++] = Equations1[i++];
                    }
                    else
                    {
                        i++;
                    }
                }
                else if (Equations2[j] < Equations1[i])
                {
                    if (Equations2[j] != 0)
                    {
                        result[index++] = Equations2[j++];
                    }
                    else
                    {
                        j++;
                    }
                }
                else
                {
                    if (Equations2[j] != 0)
                    {
                        result[index++] = Equations2[j++];
                        i++;
                    }
                    else
                    {
                        j++; i++;
                    }
                }

            }
            while (i < LA1)
            {
                if (Equations1[i] != 0)
                {
                    result[index++] = Equations1[i++];
                }
                else
                {
                    i++;
                }
            }
            while (j < LA2)
            {
                if (Equations2[j] != 0)
                {
                    result[index++] = Equations2[j++];
                }
                else
                {
                    j++;
                }
            }
            return result;
        }
    }
class Intersect
    {
        int[] Intersection(int[] Equations1, int[] Equations2, int LA1, int LA2)
        {
            int[] result = new int[LA1 + LA2];
            int index = 0, i = 0, j = 0;

            while (i < LA1 && j < LA2)
            {
                if (Equations1[i] < Equations2[j])
                {
                    i++;
                }
                else if (Equations2[j] < Equations1[i])
                {
                    j++;
                }
                else
                {
                    result[index++] = Equations2[j++];
                    i++;
                }
            }
            return result;
        }
    }


## Problems Faced
As it is a quite dificult subject so we faced many difficulties to choose this project because Ven Diagram ploted is a difficult task to ploted the ven diagram of every equations.

### Problem 1: 

#### Solving Equation
We were enable to understand the exact code of ploted ven Diagram and also faced difficulty in divide the functions of 5 group members. 
Now it was more difficlt task to solve the equation in C#.we were learned How to combine the equations and to Ploted the Ven Diagram of that equations.  

#### Problem 2: 
First we were using Union and Intersection and when we entering the large equation it was not able to recognize the error after spreading one or two days we came to conclusion that we should change update the code and be flexible to take input large equation and to plote the ven diagaram of every equations.  
## References
- [links](https://alstatr.blogspot.com/2013/11/python-venn-diagram.html).
- [links](https://stackoverflow.com/questions/25541036/creating-venn-diagram-in-c-sharp-win-form).
- [links](https://forums.asp.net/t/2085449.aspx?Making+Groups+as+a+Venn+Diagram+in+C+).

