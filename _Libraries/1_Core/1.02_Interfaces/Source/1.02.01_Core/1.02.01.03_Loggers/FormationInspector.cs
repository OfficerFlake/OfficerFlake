using System;

namespace Com.OfficerFlake.Libraries.Interfaces
{
	public interface IFormationInspector
	{
        /// <summary>
        /// Update the formation position number when a client can be assigned to that position in the team.
        /// </summary>
        /// <param name="formationPositionNumber">
        /// <para>The number in the formation that this client is occupying.</para>
        /// <para>Cannot be Null.</para>
        /// <para>Cannot be &lt; 1.</para>
        /// <para>Cannot be &gt; 9.</para>
        /// </param>
        /// <param name="username">
        /// <para>The username of the associated client for this formaton position.</para>
        /// <para>If null, changes to "&lt;Not Connected&gt;"</para>
        /// </param>
        /// <param name="flightId">
        /// <para>The Flight ID of the aircraft resonsible for flying in this position right now.</para>
        /// <para>If null, changes to "-----".</para>
        /// </param>
	    void UpdateClientFormationHost(int formationPositionNumber, string username, int? flightId); //Username and FlightID may be null to set back to blanks.

        /// <summary>
        /// Updates the formation position data for a given client-entry line.
        /// </summary>
        /// <param name="formationPositionNumber">
        /// <para>The number in the formation that this client is occupying.</para>
        /// <para>Cannot be Null.</para>
        /// <para>Cannot be &lt; 1.</para>
        /// <para>Cannot be &gt; 9.</para>
        /// </param>
        /// <param name="targetPositionNumber">
        /// <para>The number in the formation that this client is forming off.</para>
        /// <para>If Null, changes to "--"</para>
        /// <para>Cannot be &lt; 1.</para>
        /// <para>Cannot be &gt; 9.</para>
        /// </param>
        /// <param name="xPosition">
        /// <para>The X position of the aircraft.</para>
        /// <para>If in a formation, this is a RELATIVE position. Otherwise it is an ABSOLUTE position.</para>
        /// <para>If null, changes to "-----"</para>
        /// </param>
        /// <param name="yPosition">
        /// <para>The Y position of the aircraft.</para>
        /// <para>If in a formation, this is a RELATIVE position. Otherwise it is an ABSOLUTE position.</para>
        /// <para>If null, changes to "-----"</para>
        /// </param>
        /// <param name="zPosition">
        /// <para>The Z position of the aircraft.</para>
        /// <para>If in a formation, this is a RELATIVE position. Otherwise it is an ABSOLUTE position.</para>
        /// <para>If null, changes to "-----"</para>
        /// </param>
        void UpdateClientFormationPosition(int formationPositionNumber, int? targetPositionNumber, double? xPosition, double? yPosition, double? zPosition); //Target can be null for absolute, X Y Z may be null to return to blanks.

        /// <summary>
        /// Loads the host address textbox data from the settings library.
        /// </summary>
	    void UpdateHostAddressFromSettings();
	}
}
