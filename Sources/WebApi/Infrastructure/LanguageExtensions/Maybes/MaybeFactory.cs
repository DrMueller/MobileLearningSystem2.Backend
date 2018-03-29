using Mmu.Mls2.WebApi.Infrastructure.LanguageExtensions.Maybes.Implementation;

namespace Mmu.Mls2.WebApi.Infrastructure.LanguageExtensions.Maybes
{
    public static class MaybeFactory
    {
        public static Maybe<T> CreateFromNullable<T>(T possiblyNull) => possiblyNull == null ? CreateNone<T>() : CreateSome(possiblyNull);

        public static Maybe<T> CreateNone<T>() => new NoneMaybe<T>();

        public static Maybe<T> CreateSome<T>(T value) => new SomeMaybe<T>(value);
    }
}