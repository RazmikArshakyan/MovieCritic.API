using MovieCritic.Data;
using MovieCritic.Data.Entities;
using OpenAI_API;
using OpenAI_API.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCritic.Core.Services
{
    public class GptService : IGptService
    {
        // I create this object, for saving the further changes in my database
        private readonly ApplicationDbContext context;
        public GptService(ApplicationDbContext _context)
        {
            context = _context;
        }

        public string Request(string wantedMovie)
        {
            // :start
            var provideFeedback = "Provide the feedbacks of this film " + wantedMovie;

            var apiKey = "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";
            var apiModel = "gpt-3.5-turbo";

            OpenAIAPI openAIAPI = new OpenAIAPI(apiKey);
            ChatRequest chatModel = new ChatRequest();
            var request = new ChatRequest()
            {
                Messages = new List<ChatMessage>() { new ChatMessage() { Content = provideFeedback } },
                Model = apiModel,
                Temperature = 0.1,
                MaxTokens = 2000,
            };

            // :end

            // From :start to :end it's basic connections to OpenAI's reponse generator, with alwats giving 
            // the generator in form of provideFeedback variable, so it will always provide the feedback
            // according to wantedMovie variable, which user will input

            // And here I made the call to OpenAI's Chat's CreeateChat function
            var response = openAIAPI.Chat.CreateChatCompletionAsync(request).Result;

            // some checkings for not utilizing foreach
            if (response == null)
            {
                return "";
            }

            foreach (var item in response.Choices)
            {
                // here I just add request and response to RequestsTable which is in our database
                context.RequestsTable.Add(new ReqTable()
                {
                    Request = wantedMovie,
                    Response = item.Message.Content
                });

                //and of course save changes
                context.SaveChanges();
                // And after all this return wanted response
                return item.Message.Content;
            }

            return "";
        }
    }
}
