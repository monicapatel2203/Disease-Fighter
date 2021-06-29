// using UnityEngine;
// using System.Collections;
// using System.Runtime.InteropServices;



// // All Objective-C exposed methods should be bound here
// public class GDAdsBinding
// {
//     [DllImport("__Internal")]
//     private static extern void _changeLocation(System.Int64 location);

// 	// Change location of the Ads to be shown: 3 integer values can be passed
// 	// 0:main menu, 1:user failed, 3:game paused 4: gameplay
//     public static void changeLocation(System.Int64 location)
//     {
//         // Call plugin only when running on real device
//         if( Application.platform == RuntimePlatform.IPhonePlayer )
// 			_changeLocation(location);
		
//     }
	
	
// 	[DllImport("__Internal")]
//     private static extern void _blockChangeLocation(System.Int64 location);

// 	// Change location of the Ads to be shown: 3 integer values can be passed
// 	// 0:main menu, 1:user failed, 3:game paused 4: gameplay
//     public static void blockChangeLocation(System.Int64 location)
//     {
//         // Call plugin only when running on real device
//         if( Application.platform == RuntimePlatform.IPhonePlayer )
// 			_blockChangeLocation(location);
		
//     }
	
	
// 	[DllImport("__Internal")]
//     private static extern void _moreApps();

// 	//call this method to show moreApps screen
//     public static void moreApps()
//     {
//         // Call plugin only when running on real device
//         if( Application.platform == RuntimePlatform.IPhonePlayer )
// 			_moreApps();
//     }
	
	
//     [DllImport("__Internal")]
//     private static extern void _swtichOffAllAdsPermenantly();

// 	// Calling this will permanently switch off all ads, call this only when no ads be shown to user again.
// 	public static void swtichOffAllAdsPermenantld()
//     {
//         // Call plugin only when running on real device
//         if( Application.platform == RuntimePlatform.IPhonePlayer )
// 			_swtichOffAllAdsPermenantly();
//     }
	
	
// 	[DllImport("__Internal")]
//     private static extern void _callRateMe();

// 	//call this method to show moreApps screen
//     public static void callRateMe()
//     {
//         // Call plugin only when running on real device
//         if( Application.platform == RuntimePlatform.IPhonePlayer )
// 			_callRateMe();
//     }
	
// 	[DllImport("__Internal")]
//     private static extern void _purchaseWithIDIndex(int pID);

// 	//call this method to show moreApps screen
//     public static void purchaseWithIDIndex(int pID)
//     {
//         // Call plugin only when running on real device
//         if( Application.platform == RuntimePlatform.IPhonePlayer )
// 			_purchaseWithIDIndex(pID);
//     }
	
// 	[DllImport("__Internal")]
//     private static extern void _restore();

// 	//call this method to show moreApps screen
//     public static void restore()
//     {
//         // Call plugin only when running on real device
//         if( Application.platform == RuntimePlatform.IPhonePlayer )
// 			_restore();
//     }
	
// }