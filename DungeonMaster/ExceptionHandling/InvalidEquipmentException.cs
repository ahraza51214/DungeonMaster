using System;

namespace DungeonMaster.ExceptionHandling
{
    // Class for handling exception message
	public class InvalidEquipmentException : Exception
    {
        public InvalidEquipmentException(string message) : base(message) { }
    }
}