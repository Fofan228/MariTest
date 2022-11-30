using MapsterMapper;
using Mari.Client.Common.Interfaces.Managers;
using Mari.Contracts.Comments.GetRequests;
using Mari.Contracts.Comments.PostRequests;
using Mari.Contracts.Comments.Responce;
using Mari.Http.Services;

namespace Mari.Client.Common.Services.Managers;

public class CommentManager : ICommentManager
 {
     private readonly HttpSender _httpSender;
     private readonly IMapper _mapper;

     public CommentManager(HttpSender httpSender, IMapper mapper)
     {
         _httpSender = httpSender;
         _mapper = mapper;
     }
     
     public async Task Create(CommentResponse comment, CancellationToken token)
     {
         var body = _mapper.Map<CommentCreateRequest.Body>(comment);
         var request = new CommentCreateRequest(body);
         var response = await _httpSender.PostAsync(request, token);
         if (!response.IsSuccess) throw new NotImplementedException();
     }

     public async Task<IEnumerable<CommentResponse>> GetAll(Guid releaseId,CancellationToken token)
     {
         var request = new CommentGetAllRequest(new(releaseId));
         var response = await _httpSender.GetAsync(request, token);
         if (!response.IsSuccess) throw new NotImplementedException();
         return null;
     }

     public async Task UpdateComments(CommentResponse comment,CancellationToken token)
     {
         var body = _mapper.Map<CommentUpdateRequest.Body>(comment);
         var request = new CommentUpdateRequest(body);
         var response = await _httpSender.PostAsync(request, token);
         if (!response.IsSuccess) throw new NotImplementedException();
     }
     
     public async Task DeleteComments(Guid commnetId,CancellationToken token)
     {
         var request = new CommentDeleteRequest(new(commnetId));
         var response = await _httpSender.PostAsync(request, token);
         if (!response.IsSuccess) throw new NotImplementedException();
     }
     
 }

