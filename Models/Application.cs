﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace lagalt_web_api.Models;
/// <summary>
///   <see cref="Id" />
///   <br />
///   <see cref="State" />
///   <br />
///   <see cref="MotivationLetter" />
///   <br />
///   <see cref="User" />
///   <br />    
///   <see cref="Project" />
///   <br />
/// </summary>
public class Application
{
    /// <summary>
    /// Gets or sets the identifier.
    /// </summary>
    /// <value>
    /// The identifier.
    /// </value>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    /// <summary>
    /// Gets or sets the state.
    /// </summary>
    /// <value>
    /// The state.
    /// </value>
    public ApplicationState State { get; set; }
    /// <summary>
    /// Gets or sets the motivation letter.
    /// </summary>
    /// <value>
    /// The motivation letter.
    /// </value>
    public string MotivationLetter { get; set; }
    /// <summary>
    /// Gets or sets the user.
    /// </summary>
    /// <value>
    /// The user.
    /// </value>
    /// Foreign Key
    public int UserId { get; set; }

    ///Navigation Property
    public virtual User User { get; set; }
    /// <summary>
    /// Gets or sets the project.
    /// </summary>
    /// <value>
    /// The project.
    /// </value>
    /// Foreign Key
    public int ProjectId { get; set; }

    ///Navigation Property
    public virtual Project Project { get; set; }
}
/// <summary>
/// Application state.
/// </summary>
public enum ApplicationState
{
    Ventende,
    Akseptert,
    Avvist
}
