using MapsterMapper;
using Mari.Client.Common.Interfaces.Managers;
using Mari.Contracts.Comments.DeleteRequests;
using Mari.Contracts.Comments.GetRequests;
using Mari.Contracts.Comments.PostRequests;
using Mari.Contracts.Comments.PutRequests;
using Mari.Contracts.Comments.Responses;
using Mari.Http.Services;

namespace Mari.Client.Common.Services.Managers;

public class CommentManager : ICommentManager
 {
     private readonly HttpSender _httpSender;
     private readonly IMapper _mapper;

     // TODO Тестовые данные
     private static List<CommentResponse> Comments = new List<CommentResponse>()
     {
         new CommentResponse(Guid.NewGuid(), Guid.NewGuid(), 1, "Араб", "GG", "15.11.2022", false),
         new CommentResponse(Guid.NewGuid(), Guid.NewGuid(), 1, "Араб", "GG", "15.11.2022", false),
         new CommentResponse(Guid.NewGuid(), Guid.NewGuid(), 1, "Араб", "GG", "15.11.2022", false),
         new CommentResponse(Guid.NewGuid(), Guid.NewGuid(), 1, "Араб", "GG", "15.11.2022", false),

     };

     public CommentManager(HttpSender httpSender, IMapper mapper)
     {
         _httpSender = httpSender;
         _mapper = mapper;
     }
     
     public async Task Create(CommentResponse comment, CancellationToken token = default)
     {
         var body = _mapper.Map<CommentCreateRequest.Body>(comment);
         var request = new CommentCreateRequest(body);
         var response = await _httpSender.PostAsync(request, token);
         if (!response.IsSuccess) throw new NotImplementedException();
     }

     public async Task<IList<CommentResponse>> GetAllUserComment(Guid releaseId,CancellationToken token = default)
     {
         var request = new CommentUserGetAllRequest(new(releaseId));
         var response = await _httpSender.GetAsync(request, token);
         if (!response.IsSuccess) throw new NotImplementedException();
         return null;
     }

     public async Task<IList<CommentResponse>> GetAllSystemComment(Guid releaseId, CancellationToken token = default)
     {
         var request = new CommentUserGetAllRequest(new(releaseId));
         var response = await _httpSender.GetAsync(request, token);
         if (!response.IsSuccess) throw new NotImplementedException();
         return null;
     }

     public async Task UpdateComments(CommentResponse comment,CancellationToken token = default)
     {
         var body = _mapper.Map<CommentUpdateRequest.Body>(comment);
         var request = new CommentUpdateRequest(body);
         var response = await _httpSender.PutAsync(request, token);
         if (!response.IsSuccess) throw new NotImplementedException();
     }
     
     public async Task DeleteComments(Guid commnetId,CancellationToken token = default)
     {
         var request = new CommentDeleteRequest(new(commnetId));
         var response = await _httpSender.DeleteAsync(request, token);
         if (!response.IsSuccess) throw new NotImplementedException();
     }
     
 }

