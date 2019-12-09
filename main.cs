using System;
using System.Collections.Generic;	// used for List
using System.Linq;					// used for List.First(), List.OrderBy();

/// <summary>
/// Merge class to get sorted list using merge algorithm.
/// </summary>
class Merge {
	/// <summary>
	/// Recursive function to divide list. Call "merge" function to get sorted list at the end.
	/// <param name="unsorted">Target list that will be sorted</param name>
	/// </summary>
	public static List<int> mergeSort(List<int> unsorted) {
		if(unsorted.Count <= 1) return unsorted;

		List<int> left = new List<int>();
		List<int> right = new List<int>();
		int middleIndex = unsorted.Count / 2;	
		// Dividing unsorted list
		for(int i = 0; i < middleIndex; i++) 
			left.Add(unsorted[i]);			
		for(int i = middleIndex; i < unsorted.Count; i++) 
			right.Add(unsorted[i]);			
		
		left = mergeSort(left);
		right = mergeSort(right);
		return merge(left, right);
	}

	/// <summary>
	/// Add smaller item to list first to get sorted list.
	/// <param name="left">The left side of divided list</param name>
	/// <param name="right">The right side of divided list</param name>
	/// </summary>
	public static List<int> merge(List<int> left, List<int> right) {
		List<int> result = new List<int>();
		while(left.Count > 0 || right.Count > 0) {
			if(left.Count > 0 && right.Count > 0) {
				// Comparing First two elements to see which is smaller
				if(left.First() <= right.First()) {
					result.Add(left.First());
					left.Remove(left.First());
				}else{
					result.Add(right.First());
					right.Remove(right.First());
				}
			}else if(left.Count > 0) {
				result.Add(left.First());
				left.Remove(left.First());
			}else if(right.Count > 0) {
				result.Add(right.First());
				right.Remove(right.First());
			}
		}

		return result;
	}
}

/// <summary>
/// Main class.
/// </summary>
class MainClass {
	public static void Main (string[] args) {
		playMerge();
	}

	/// <summary>
	/// Set random sorted list and try to sort it by Merge class methods.
	/// </summary>
	static void playMerge() {
		List<int> unsorted = new List<int>();
		var elements = new [] {1, 2, 3, 4, 5, 6, 7};
		unsorted.InsertRange(0, elements);
		// Shuffle list
		unsorted = unsorted.OrderBy(a => Guid.NewGuid()).ToList();
		Console.WriteLine("Original List: {0}", string.Join(" ", unsorted));

		Merge Merge = new Merge();
		List<int> sorted = Merge.mergeSort(unsorted);
		Console.WriteLine("Sorted List  : {0}", string.Join(" ", sorted));
	}
}