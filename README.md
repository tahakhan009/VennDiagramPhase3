# VennDiagramPhase3
DMSpring2020: Project phase3(group leader:Taha khan)
#DM 103347: VennDiagram#

###PROJECT MEMBERS###
StdID | Name
------------ | -------------
**63646** | **Taha Khan** 
62381 | Hamza Raza 
61880 | Umair Mehdi
62371 | Anas
 | Hasnain Tariq

## Project Description ##
Venn diagrams are great for illustrating the relationship between two or three groups, you can easily see the commonalities and differences.

The Venn diagram of librarians and technologists together clearly defines values and cultures that are unique and individual to each profession, yet it also has a solid center section of overlapping values and cultures that provide a solid common ground for cooperation, collaboration, and convergence. It is these areas that form the core opportunities for bringing professions together, and from which inroads can be made to further expand a common culture among information professionals.

Information
This is the obvious overlapping value, but it is the foundation upon which all these values (shared or separate) are formed. Libraries and technology organizations are information-based support structures designed to relate people to information. They are workflow-agnostic, having application across the institution, and as noted previously, they themselves are now joined together directly with the rise of electronic library services. They are also increasingly dealing with broadening definitions of information. At one time, information (collected by libraries and technologists) was principally print-based. Now multimedia materials are prevalent and reshaping the boundaries of what may be considered a library collection, or what types of data may be stored in a database. In reality, there should be no boundaries when it comes to information that may be relevant for libraries or technology organizations to pursue, capture, and make available. The future will require both professions to work very closely together to deliver these information systems to users.

##Discrete Math Concepts Used ##
In this project we have to  use vennDiagram(union,intersection).
we were solve the equations and drawn the ven diagram of each quation.

###Example 1: ###

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


##Problems Faced##
we were faced more problems just like to solve equation and to ploting the ven diagram. we were read some articles and thesis and to learn xml, how to ploting the ven diagram in this project. 

###Problem 1: sove Equation ###
Now it was more difficlt task to solve the equation in C#.we were learned xml and to combine all the equations and to make three functions one is union and second is intersection and third is stack.  

####Problem 2: Ploting Venn diagram####
It was very easy through MathPlotLib in Python becaue mathplotlib to provide the library ven diagram. so we were to learn the XML and to ploting the ven diagram. ploting ven diagram in 'x' axis or 'y' axiis

##References##
- [links](https://alstatr.blogspot.com/2013/11/python-venn-diagram.html).
