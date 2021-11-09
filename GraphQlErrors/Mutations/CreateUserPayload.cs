using HotChocolate.Types;

namespace GraphQlErrors.Mutations
{
    public class CreateUserPayload
    {
        public User User { get; set; }
        public ICreateUserError[] Errors { get; set; }
    }

    public class CreateUserPayloadType : ObjectType<CreateUserPayload>
    {
        protected override void Configure(IObjectTypeDescriptor<CreateUserPayload> descriptor)
        {
            descriptor.Field(x => x.Errors).Type<ListType<NonNullType<CreateUserErrorType>>>();
        }
    }

    public class CreateUserErrorType : UnionType
    {
        protected override void Configure(IUnionTypeDescriptor descriptor)
        {
            descriptor.Name("CreateUserError");
            descriptor.Type<UserNameTakenType>();
            descriptor.Type<PasswordTooShortType>();
            descriptor.Type<MustBeOver18Type>();
        }
    }

    public class User
    {
        public string UserName { get; set; }
    }

    public interface ICreateUserError
    {
        string Message { get; set; }
        string Path { get; set; }
    }

    public class UserErrorType : InterfaceType<ICreateUserError>
    {
        protected override void Configure(IInterfaceTypeDescriptor<ICreateUserError> descriptor)
        {
            descriptor.Name("UserError");
        }
    }

    public class UserNameTaken : ICreateUserError
    {
        public string Message { get; set; }
        public string Path { get; set; }
        public string Suggestion { get; set; }
    }

    public class UserNameTakenType : ObjectType<UserNameTaken>
    {
        protected override void Configure(IObjectTypeDescriptor<UserNameTaken> descriptor)
        {
            descriptor.Implements<UserErrorType>();
        }
    }

    public class PasswordTooShort : ICreateUserError
    {
        public string Message { get; set; }
        public string Path { get; set; }
        public int MinLength { get; set; }
    }

    public class PasswordTooShortType : ObjectType<PasswordTooShort>
    {
        protected override void Configure(IObjectTypeDescriptor<PasswordTooShort> descriptor)
        {
            descriptor.Implements<UserErrorType>();
        }
    }

    public class MustBeOver18 : ICreateUserError
    {
        public string Message { get; set; }
        public string Path { get; set; }
    }

    public class MustBeOver18Type : ObjectType<MustBeOver18>
    {
        protected override void Configure(IObjectTypeDescriptor<MustBeOver18> descriptor)
        {
            descriptor.Implements<UserErrorType>();
        }
    }
}
