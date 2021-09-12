using System.Reflection;
using HarmonyLib;
using DMT;
using UnityEngine;

namespace Harmony_Mikado_Core
{

	public class ChangetutorialTipQuest01Text
	{
        public class Init : IHarmony
        {
            public void Start()
            {
                Debug.Log((object)("Mikado Loading Patch : " + this.GetType().ToString()));
                new Harmony(this.GetType().ToString()).PatchAll(Assembly.GetExecutingAssembly());
            }
        }

		// Removes the Tool Tips for Journal
		[HarmonyPatch(typeof(XUiC_TipWindow))]
		[HarmonyPatch("ShowTip")]
		public class XUiC_TipWindow_ShowTip
		{
			static bool Prefix(ref string tip, EntityPlayerLocal _localPlayer, ToolTipEvent closeEvent)
			{
				if (tip == "tutorialTipQuest01")
					tip = "alt_tutorialTipQuest01";
				return true;
			}
		}
	}
}
