using Sdayu.DAL.Extensions;
using Sdayu.DAL.Types.Domain.Enums;
using Xunit;

namespace Sdayu.DAL.Tests.Utils
{
    public class EnumExtension
    {
        [Theory]
        [InlineData(Role.Admin, "admin")]
        [InlineData(Role.Landlord, "landlord")]
        [InlineData(Role.Tenant, "tenant")]
        public void EnumExtensions_GetGetEnumMember_MemberIsGotten(Role userRole, string expected)
        {
            // Arrange

            // Act
            var value = userRole.GetEnumMemberAttrValue();
            
            // Assert
            Assert.Equal(expected, value);
        }
    }
}