using System;
using DungeonMaster.Enums;

namespace DungeonMaster.Interfaces
{
	// Interface for items
	public interface IItem
	{
		string Name { get; }
		int RequiredLevel { get; }
		Slot Slot { get; }
	}
}