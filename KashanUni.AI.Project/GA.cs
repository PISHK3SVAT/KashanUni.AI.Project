using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KashanUni.AI.Project
{
    public class GA<T>
    {
        private Chromosome<T>[] population;

        public GA(int populationSize, int chromosomSize)
        {
            population = new Chromosome<T>[populationSize];

            for (int i = 0; i < populationSize; i++)
            {
                population[i]=new Chromosome<T> (chromosomSize);
            }
        }

        public Chromosome<T>[] Execute(int stopCount, double crossOverProb)
        {
            InitialPopulation();
            for (int i = 1; i <= stopCount; i++)
            {
                Evaluate();
                var parents=RandomParentSelection();
                var childrens=UniformCrossOver(crossOverProb, parents.a, parents.b);
                Mutation(childrens.a);
                Mutation(childrens.b);
                ChangePopulation(childrens.a,childrens.b);
            }
            return population;
        }
        void InitialPopulation()
        {

        }
        void Evaluate()
        {

        }
        (Chromosome<T> a, Chromosome<T> b) RandomParentSelection()
        {
            return (population[0], population[1]);
        }
        (Chromosome<T> a, Chromosome<T> b) UniformCrossOver(double pc,Chromosome<T> a, Chromosome<T> b)
        {
            return (population[0], population[1]);
        }
        void Mutation(Chromosome<T> child)
        {

        }
        void RoulteteWheel()
        {

        }
        void ChangePopulation(Chromosome<T> child1, Chromosome<T> child2)
        {

        }
    }

    public class Chromosome<T>(int n)
    {
        private readonly int n=n;
        private T[] chromosomes=new T[n];

        public T[] Chromosomes 
        { 
            get => chromosomes;
            set
            {
                if (value.Length != n)
                    throw new ArgumentOutOfRangeException();
                for (int i = 0; i < n; i++)
                    chromosomes[i] = value[i];
            }
        }
    }
}
