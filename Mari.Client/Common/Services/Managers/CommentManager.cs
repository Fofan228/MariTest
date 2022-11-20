// namespace Mari.Client.Common.Services.Managers;

// public class CommentManager : ICommentManager
// {
//     private static List<CommentAnswer> Comments = new List<CommentAnswer>()
//     {
//         new CommentAnswer("0000-0000-0000-0000","1" , "Араб", "GG", "15.11.2022",false),
//         new CommentAnswer("0000-0000-0000-0000","1" , "Араб", "GG", "15.11.2022",false),
//         new CommentAnswer("0000-0000-0000-0000","1" , "Араб", "GG", "15.11.2022",false),
//         new CommentAnswer("0000-0000-0000-0000","1" , "Араб","GG", "15.11.2022",false),
//         new CommentAnswer("0000-0000-0\0" +
//                           "00-0000","1" , "Араб", "GG", "15.11.2022",false)
//     };


//     public void Post(CommentPostRequest request)
//     {
//         Comments.Add(new CommentAnswer(
//             request.ReleaseId,
//             request.UserId,
//             request.UserName,
//             request.Information,
//             "15.11.2022 0:34",   //Todo время 
//             false
//         ));
//     }

//     public async Task<List<CommentAnswer>> GetAll(CommentRequest request)
//     {
//         return Comments;
//     }

// }
