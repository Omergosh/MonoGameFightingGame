using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonoFightingGameProject;
using MonoFightingGameProject.utils;
using MonoFightingGameProject.ActionStates;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.IsTrue(1 == 1);
        }

        [TestMethod]
        public void TestRegisterCommonCombatState()
        {
            Assert.IsNull(CombatStateRegistry.CombatStatesCommon[(int)CombatStateID.Standing]);
            Assert.IsNull(CombatStateRegistry.CombatStatesCommon[0]);

            CombatStateRegistry.RegisterCommonState(CombatStateID.Standing, new StandingState());

            Assert.IsNotNull(CombatStateRegistry.CombatStatesCommon[(int)CombatStateID.Standing]);
            Assert.IsNotNull(CombatStateRegistry.CombatStatesCommon[0]);
            Assert.IsNull(CombatStateRegistry.CombatStatesCommon[(int)CombatStateID.Crouching]);
            Assert.IsNull(CombatStateRegistry.CombatStatesCommon[1]);
        }
    }
}
