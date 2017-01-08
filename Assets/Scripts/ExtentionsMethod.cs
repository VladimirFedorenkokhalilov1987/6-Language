using UnityEngine;
using System.Linq;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



	public static class ExtentionsMethod
	{
		public static string GetTotalString(this List<string> collection)
		{
			if (collection == null || collection.Count == 0)
				return null;

			StringBuilder result = new StringBuilder ();

			foreach (var item in collection) {
				result.Append(string.Format("{0}",item));
			}
			return result.ToString ();
		}

	public static List< Dropdown.OptionData> GetOptionData(this List<string> collection)
	{
	if (collection == null || collection.Count == 0)
		return null;
	
	List <Dropdown.OptionData> data = new List<Dropdown.OptionData> ();

	foreach (var item in collection) {
		data.Add (new Dropdown.OptionData{ text = item });
	}
	return data;
	}

	public static bool IsNullOrEmpty<T>(this IEnumerable<T> collection)
	{
		if (collection == null || collection.Count () == 0)
			return true;
		return false;
	}

	public static T GetRandomItem<T>(this IEnumerable<T> collection) where T :class
	{
		if (collection.IsNullOrEmpty ())
			return null;
		int index = Random.Range (0, collection.Count ());
		return collection.ElementAt (index);
	}
}