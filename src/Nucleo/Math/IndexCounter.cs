using System;
using Nucleo.Collections;


namespace Nucleo.Math
{
	public static class IndexCounter
	{
		public static IndexRowCollection CreateHorizontalRepeatableIndexes(int startValue, int endValue, int repeatColumnCount)
		{
			if (endValue <= startValue)
				throw new ArgumentOutOfRangeException("endValue");
			if (repeatColumnCount <= 0 || repeatColumnCount >= (endValue - startValue))
				throw new ArgumentOutOfRangeException("repeatColumnCount");

			IndexRowCollection rows = new IndexRowCollection();
			IndexRow row = new IndexRow();
			rows.Add(row);
			int count = 0;

			for (int index = startValue; index <= endValue; index++)
			{
				if (count != 0 && count % repeatColumnCount == 0)
				{
					row = new IndexRow();
					rows.Add(row);
				}

				row.Values.Add(index);
				count++;
			}

			return rows;
		}

		public static IndexRowCollection CreateRepeatableIndexes(int startValue, int endValue, int repeatColumnCount, IndexRepeatDirection repeatDirection)
		{
			if (repeatDirection == IndexRepeatDirection.Horizontal)
				return CreateHorizontalRepeatableIndexes(startValue, endValue, repeatColumnCount);
			else
				return CreateVerticalRepeatableIndexes(startValue, endValue, repeatColumnCount);
		}


		public static IndexRowCollection CreateVerticalRepeatableIndexes(int startValue, int endValue, int repeatColumnCount)
		{
			if (endValue <= startValue)
				throw new ArgumentOutOfRangeException("endValue");
			if (repeatColumnCount <= 0 || repeatColumnCount >= (endValue - startValue))
				throw new ArgumentOutOfRangeException("repeatColumnCount");

			IndexRowCollection rows = new IndexRowCollection();
			int rowCount = Convert.ToInt32(System.Math.Ceiling(
				Convert.ToDecimal(endValue - startValue) / 
				Convert.ToDecimal(repeatColumnCount)));

			decimal divisingIndex = System.Math.Ceiling(Convert.ToDecimal(endValue - startValue) / Convert.ToDecimal(repeatColumnCount));
			
			for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
			{
				IndexRow newRow = new IndexRow();
				rows.Add(newRow);
				int value = startValue + rowIndex;

				for (int index = 0; index < repeatColumnCount; index++)
				{
					if (index != 0)
						value += Convert.ToInt32(divisingIndex);

					newRow.Values.Add(value);
				}
			}

			return rows;
		}
	}
}
