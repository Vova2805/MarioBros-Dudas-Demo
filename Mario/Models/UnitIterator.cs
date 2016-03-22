using Lab5_KPZ.Models.Flyweight;
using System.Collections.Generic;
using System.Linq;

namespace Lab5_KPZ.Models
{
	class UnitIterator
	{
		private readonly List<List<MapUnit>> _mapUnits;
		private int _currentList;
		private int insideIndex;

		public UnitIterator(Level _level,int _mapIndex)
		{
			_mapUnits = new List<List<MapUnit>>();
			_mapUnits.Add(new List<MapUnit>() {_level._Mario});
			if (GeneralObject._gameViewModel._quantity.Equals("Two")) _mapUnits.ElementAt(0).Add(_level._Luigi);
			_mapUnits.Add(_level._Maps.ElementAt(_mapIndex).Enemies);
			_mapUnits.Add(_level._Maps.ElementAt(_mapIndex).Blocks);
			_mapUnits.Add(_level._Maps.ElementAt(_mapIndex).Bonuses);
			_mapUnits.Add(_level._Maps.ElementAt(_mapIndex).Coins);
			
			_currentList = 0;
			insideIndex = 0;
		}
		public bool HasNext()
		{
			if (_currentList < _mapUnits.Count) return true;
			if (_currentList == _mapUnits.Count - 1)
				if (insideIndex < _mapUnits.ElementAt(_currentList).Count)
					return true;
			return false;
		}
		public MapUnit NextUnit()
		{
			MapUnit Next = null;
			if(_currentList<_mapUnits.Count)
			{
				if(insideIndex< _mapUnits.ElementAt(_currentList).Count)
				{
					Next = _mapUnits.ElementAt(_currentList).ElementAt(insideIndex);
					insideIndex++;
				}
				else
				{
					_currentList++;
					insideIndex = 0;
					return NextUnit();
                }
			}
			return Next;
		}
		public List<MapUnit> GetList(MapUnit Unit)
		{
			_currentList = 0;
			insideIndex = 0;
            while (HasNext())
			{
				var unit = NextUnit();
				if(Unit.Position.Equals(unit.Position))
					return _mapUnits.ElementAt(_currentList);
			}
			return null;
		}
	}
}
