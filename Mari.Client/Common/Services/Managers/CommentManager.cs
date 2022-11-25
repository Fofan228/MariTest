using MapsterMapper;
using Mari.Client.Common.Interfaces.Managers;
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

     public void GetAll(Guid releaseId)
     {
         throw new NotImplementedException();
     }

     public void UpdateComments(Guid commnetId)
     {
         throw new NotImplementedException();
     }

     public void DeleteComments(Guid commnetId)
     {
         throw new NotImplementedException();
     }
     
 }

