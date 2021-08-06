using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DNA
{

	List<int> genes = new List<int>();
	int dnaLength = 0;
	int maxValues = 0;

	public DNA(int l, int v)
	{
		dnaLength = l;
		maxValues = v;
		SetRandom();
	}
	//put random values on the genes
	public void SetRandom()
	{
		genes.Clear();
		for (int i = 0; i < dnaLength; i++)
		{
			genes.Add(Random.Range(0, maxValues));
		}
	}
	//for testing 
	public void SetInt(int pos, int value)
	{
		genes[pos] = value;
	}
	// combine the gene with parent :first half of gene from parent "d1" , and the second half from second parent "d2".
	public void Combine(DNA d1, DNA d2)
	{
		for (int i = 0; i < dnaLength; i++)
		{
			if (i < dnaLength / 2.0)
			{
				int c = d1.genes[i];
				genes[i] = c;
			}
			else
			{
				int c = d2.genes[i];
				genes[i] = c;
			}
		}
	}

	public void Mutate()
	{
		genes[Random.Range(0, dnaLength)] = Random.Range(0, maxValues);
	}

	public int GetGene(int pos)
	{
		return genes[pos];
	}

}

