using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KashanUni.AI.Project
{
    public class GA<T>
    {
        public (Chromosome<T> chromosome, double fitness)[] population;
        public Func<Chromosome<T>,double> Evaluate;
        public GA(int populationSize, int chromosomSize, List<T> allel, Func<Chromosome<T>, double> evaluate)
        {
            population = new (Chromosome<T> chromosome, double fitness)[populationSize];
            for (int i = 0; i < populationSize; i++)
            {
                population[i] = (new Chromosome<T>(chromosomSize, allel), 0);
            }
            Evaluate = evaluate;
        }

        public (Chromosome<T> chromosome, double fitness)[] Execute(int stopCount, double crossOverProb, double mutaionProb, double mutationGenProb)
        {
            InitialPopulation();
            for (int i = 1; i <= stopCount; i++)
            {
                EvaluateAll();
                var parents=RandomParentSelection();
                var childrens=UniformCrossOver(crossOverProb, parents.a, parents.b);
                Mutation(mutaionProb, mutationGenProb, childrens.a);
                Mutation(mutaionProb, mutationGenProb, childrens.b);
                ChangePopulation(childrens.a,childrens.b);
            }
            return population;
        }
        public void InitialPopulation()
        {
            for (int i = 0;i < population.Length; i++)
            {
                var chromose = population[i].chromosome;
                for(int j = 0; j < chromose.Values.Length; j++)
                {
                    var rnd = new Random();
                    var index = rnd.Next(0, chromose.allel.Count);
                    chromose[j] = chromose.allel[index];
                }
            }
        }
        
        void EvaluateAll()
        {
            for (int i = 0; i < population.Length; i++)
            {
                var tmp = population[i];
                tmp.fitness = Evaluate(tmp.chromosome);
            }
        }
        (Chromosome<T> a, Chromosome<T> b) RandomParentSelection()
        {
            return (population[0].chromosome, population[1].chromosome);
        }
        (Chromosome<T> a, Chromosome<T> b) UniformCrossOver(double pc,Chromosome<T> a, Chromosome<T> b)
        {
            var n = a.Values.Length;
            var child1 = new Chromosome<T>(n,a.allel);
            var child2 = new Chromosome<T>(n, a.allel);
            for(int i = 0; i < a.Values.Length; i++)
            {
                var rnd = new Random();
                var value = rnd.NextDouble();
                if (value < pc)
                {
                    child1[i] = b[i];
                    child2[i] = a[i];
                }
                else
                {
                    child1[i] = a[i];
                    child2[i] = b[i];
                }
            }
            return (child1, child2);
        }
        void Mutation(double pm, double pg, Chromosome<T> child)
        {
            var rnd = new Random();
            var value = rnd.NextDouble();
            if (value < pm)
            {
                for (int i = 0; i < child.Values.Length; i++)
                {
                    value = rnd.NextDouble();
                    if (value < pg)
                    {
                        var index = rnd.Next(0, child.allel.Count);
                        child[i] = child.allel[index];
                    }
                }
            }
        }
        void RoulteteWheel()
        {
            
        }
        void ChangePopulation(Chromosome<T> child1, Chromosome<T> child2)
        {

        }
    }
}
