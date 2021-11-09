using HotChocolate;
using HotChocolate.Types;

namespace GraphQlErrors.Mutations
{
    [ExtendObjectType("Mutation")]
    public class CreateUserMutation
    {
        [GraphQLType(typeof(CreateUserPayloadType))]
        public CreateUserPayload CreateUser()
        {
            return new CreateUserPayload
            {
                Errors = new ICreateUserError[]
                {
                    new UserNameTaken
                    {
                        Message = "Username already in use",
                        Path = "How...",
                        Suggestion = "Coolio69"
                    },
                    new PasswordTooShort
                    {
                        Message = "Password too short",
                        Path = "",
                        MinLength = 8,
                    },
                    new MustBeOver18
                    {
                        Message = "You must be over 18 to use this service",
                        Path = ""
                    }
                }
            };
        }
    }

    [ExtendObjectType("Query")]
    public class DummyQuery
    {
        public bool GetProduct()
        {
            return true;
        }
    }
}
