namespace Twitter.Clone.Handlers.DTOs;
public record PostCreatedDto(string PostId, string Content, string CreatedByUserName, DateTime CreatedTime);
