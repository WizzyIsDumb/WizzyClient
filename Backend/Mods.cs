using dark.efijiPOIWikjek;
using GTAG_NotificationLib;
using Photon.Pun;
using Photon.Realtime;
using MalachiTemp.UI;
using MalachiTemp.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Text = UnityEngine.UI.Text;
using TMPro;
using ExitGames.Client.Photon;
using GorillaLocomotion.Gameplay;
using Photon.Voice.PUN.UtilityScripts;
using Fusion;
using GorillaNetworking;


namespace MalachiTemp.Backend
{
    /*
       PROTECTION NOTE: THIS TEMPLATE IS PROTECTED MATERIAL FROM "Project Malachi". 
       IF ANY MATERIAL FROM "MalachiTemp" FOUND IN ANY OTHER PROJECT/THING WITHOUT 
       CREDIT OR PERMISSION MUST AND WILL BE REMOVED IMMEDIATELY
    */
    internal class Mods : MonoBehaviour
    {
        // Double click a grey square to open it, click the - in the box to the left of "#region" to close it
        #region Shit
        public static void Moo()
        {
            GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/motd (1)").GetComponent<TextMeshPro>().text = "Welcome To Wizzy Client, If you get banned using any of these mods report to discord, and ill fix!";
            GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/motdtext").GetComponent<TextMeshPro>().text = "Cool monkey menu half und!!1";
            GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/CodeOfConduct").GetComponent<TextMeshPro>().text = "Wizzy Client";
            GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/COC Text").GetComponent<TextMeshPro>().text = "Nothing here nigga";
        }
        public static void DisableButton(string name)
        {
            GetButton(name).enabled = new bool?(false);
            WristMenu.DestroyMenu();
            WristMenu.instance.Draw();
        }
        public static void PLACEHOLDER()
        {
            // DONT PUT ANYTHING IN HERE
        }
        public static void DrawHandOrbs()
        {
            orb = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            orb2 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            Destroy(orb.GetComponent<Rigidbody>());
            Destroy(orb.GetComponent<SphereCollider>());
            Destroy(orb2.GetComponent<Rigidbody>());
            Destroy(orb2.GetComponent<SphereCollider>());
            orb.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            orb2.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            orb.transform.position = GorillaTagger.Instance.leftHandTransform.position;
            orb2.transform.position = GorillaTagger.Instance.rightHandTransform.position;
            orb.GetComponent<Renderer>().material.color = CurrentGunColor;
            orb2.GetComponent<Renderer>().material.color = CurrentGunColor;
            Destroy(orb, Time.deltaTime);
            Destroy(orb2, Time.deltaTime);
        }
        #endregion
        #region Movement
        public static void FlyMeth(float speed)
        {
            if (WristMenu.abuttonDown)
            {
                GorillaLocomotion.Player.Instance.transform.position += GorillaLocomotion.Player.Instance.headCollider.transform.forward * Time.deltaTime * speed;
                GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
        }
        public static void MatUsing()
        {
            if (GorillaGameManager.instance != null)
            {
                foreach (GorillaTagManager gorillaTagManager in GameObject.FindObjectsOfType<GorillaTagManager>())
                {
                    foreach (Player player in PhotonNetwork.PlayerList)
                    {
                        gorillaTagManager.currentInfected.Remove(player);
                        gorillaTagManager.AddInfectedPlayer(player);
                        gorillaTagManager.currentInfected.Remove(player);
                        gorillaTagManager.currentInfectedArray[player.ActorNumber] = 0;
                        gorillaTagManager.AddInfectedPlayer(player);
                        gorillaTagManager.currentInfected.Remove(player);
                        gorillaTagManager.currentInfectedArray[player.ActorNumber] = 0;
                    }
                }
            }
        }
       public static void DisablNetworkTriggas()
       {
            GameObject.Find("EnviromentObjects/TriggerZone_Prefab/JoinRoomTriggers_Prefab").SetActive(false);
       }
       public static void EnableNetworkTriggas()
       {
            GameObject.Find("EnviromentObjects/TriggerZone_Prefab/JoinRoomTriggers_Prefab").SetActive(true);
       }
       


        public static void AddInfected()
        {
            foreach (GorillaTagManager gorillaTagManager in GameObject.FindObjectsOfType<GorillaTagManager>())
            {
                foreach (Player player in PhotonNetwork.PlayerListOthers)
                {
                    gorillaTagManager.currentInfected.Add(player);
                }
            }
        }
        public static void SlipSLAP()
        {
            GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest/Terrain/pitgeo/pit lower slippery wall").GetComponent<GorillaSurfaceOverride>().extraVelMaxMultiplier = 9.3f;
            GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest/Terrain/pitgeo/pit upper slippery wall").GetComponent<GorillaSurfaceOverride>().extraVelMaxMultiplier = 10f;
        }
       



























        public static void TagAll()
        {
            foreach (Player player in PhotonNetwork.PlayerListOthers)
            {
                if (!ControllerInputPoller.instance.rightGrab)
                {
                    GorillaTagger.Instance.offlineVRRig.enabled = true;
                }
                else
                {
                    foreach (GorillaTagManager gorillaTagManager in GameObject.FindObjectsOfType<GorillaTagManager>())
                    {
                        if (!gorillaTagManager.currentInfected.Contains(player))
                        {
                            GorillaTagger.Instance.offlineVRRig.enabled = false;
                            GorillaTagger.Instance.offlineVRRig.transform.position = GorillaGameManager.instance.FindPlayerVRRig(player).transform.position;
                            GorillaTagger.Instance.rightHandTransform.position = GorillaGameManager.instance.FindPlayerVRRig(player).transform.position;
                        }
                    }
                }
            }
        }

        public static void MatSpamAll()
        {
            foreach (GorillaTagManager gorillaTagManager in GameObject.FindObjectsOfType<GorillaTagManager>())
            {
                foreach (Player player in PhotonNetwork.PlayerList)
                {
                    gorillaTagManager.currentInfected.Contains(player);
                    gorillaTagManager.AddInfectedPlayer(player);
                    gorillaTagManager.currentInfected.Remove(player);
                    gorillaTagManager.AddInfectedPlayer(player);
                    gorillaTagManager.currentInfected.Remove(player);
                    gorillaTagManager.currentInfected.Remove(player);
                    gorillaTagManager.AddInfectedPlayer(player);
                    gorillaTagManager.currentInfected.Remove(player);
                    gorillaTagManager.AddInfectedPlayer(player);
                    gorillaTagManager.currentInfected.Remove(player);
                    gorillaTagManager.AddInfectedPlayer(player);
                    gorillaTagManager.currentInfected.Remove(player);
                    gorillaTagManager.AddInfectedPlayer(player);
                    gorillaTagManager.currentInfected.Remove(player);
                    gorillaTagManager.AddInfectedPlayer(player);
                    gorillaTagManager.currentInfected.Remove(player);
                    Mods.MatUsing();
                }
            }
        }


        public static void Platforms()
        {
            PlatformsThing(invisplat, stickyplatforms);
        }
        public static void Invisableplatforms()
        {
            PlatformsThing(true, false);
        }
        public static void Noclip()
        {
            foreach (MeshCollider m in Resources.FindObjectsOfTypeAll<MeshCollider>())
            {
                if (WristMenu.triggerDownR)
                {
                    m.enabled = false;
                }
                else
                {
                    m.enabled = true;
                }
            }
        }
        #endregion
        #region Rig Mods
        public static void Ghostmonke()
        {
            if (right)
            {
                GorillaTagger.Instance.offlineVRRig.enabled = !ghostMonke;
                if (ghostMonke)
                {
                    DrawHandOrbs();                 
                }
                if (WristMenu.ybuttonDown && !lastHit)
                {
                    ghostMonke = !ghostMonke;
                }
                lastHit = WristMenu.ybuttonDown;
            }
            else
            {
                GorillaTagger.Instance.offlineVRRig.enabled = !ghostMonke;
                if (ghostMonke)
                {
                    DrawHandOrbs();
                }
                if (WristMenu.bbuttonDown && !lastHit)
                {
                    ghostMonke = !ghostMonke;
                }
                lastHit = WristMenu.bbuttonDown;
            }
        }
        public static VRRig GetRigFromGun()
        {
            return Mods.raycastHit.collider.GetComponentInParent<VRRig>();
        }
        public static void GripRig()
        {
            if (WristMenu.gripDownR && !WristMenu.gripDownL)
            {
                DrawHandOrbs();
                GorillaTagger.Instance.offlineVRRig.enabled = false;
                GorillaTagger.Instance.offlineVRRig.transform.position = GorillaLocomotion.Player.Instance.rightControllerTransform.position;
            }
            if (WristMenu.gripDownR && !WristMenu.gripDownR)
            {
                DrawHandOrbs();
                GorillaTagger.Instance.offlineVRRig.enabled = false;
                GorillaTagger.Instance.offlineVRRig.transform.position = GorillaLocomotion.Player.Instance.leftControllerTransform.position;
            }
            if (!WristMenu.gripDownR && WristMenu.gripDownL)
            {
                GorillaTagger.Instance.offlineVRRig.enabled = true;
            }
        }
       
        
        public static void GrabIDCard()
        {
            bool rightGrab = ControllerInputPoller.instance.rightGrab;
            if (rightGrab)
            {
                GameObject gameObject = GameObject.Find("ID Card Holdable");
                bool flag = gameObject.GetComponent<TransferrableObject>().ownerRig != GorillaTagger.Instance.offlineVRRig;
                if (flag)
                {
                    gameObject.GetComponent<TransferrableObject>().WorldShareableRequestOwnership();
                }
                gameObject.transform.position = GorillaTagger.Instance.rightHandTransform.position;
            }
        }
       

       

        private static void BetaSetStatus(int v, RaiseEventOptions raiseEventOptions)
        {
            throw new NotImplementedException();
        }

        public static void BreakRopes()
        {
            foreach (GorillaRopeSwingSettings gorillaRopeSwingSettings in GameObject.FindObjectsOfType(typeof(GorillaRopeSwingSettings)))
            {
                bool flag = gorillaRopeSwingSettings.name.Contains("Default");
                if (flag)
                {
                    gorillaRopeSwingSettings.inheritVelocityMultiplier = 4f;
                }
            }
        }


        private static GliderHoldable[] GetGliders()
        {
            throw new NotImplementedException();
        }

        public static void RigGun()
        {
            MakeGun(CurrentGunColor, new Vector3(0.15f, 0.15f, 0.15f), 0.025f, PrimitiveType.Sphere, GorillaLocomotion.Player.Instance.rightControllerTransform, true, delegate
            {
                GorillaTagger.Instance.offlineVRRig.enabled = false;
                GorillaTagger.Instance.offlineVRRig.transform.position = pointer.transform.position + new Vector3(0f, 0.3f, 0f);

            }, delegate { GorillaTagger.Instance.offlineVRRig.enabled = true; });
        }
        public static void TestGun()
        {
            MakeGun(CurrentGunColor, new Vector3(0.15f, 0.15f, 0.15f), 0.025f, PrimitiveType.Sphere, GorillaLocomotion.Player.Instance.rightControllerTransform, true, delegate
            {
                GorillaTagger.Instance.offlineVRRig.enabled = false;
                GorillaTagger.Instance.offlineVRRig.transform.position = pointer.transform.position + new Vector3(0f, 0.3f, 0f);
                GorillaTagger.Instance.offlineVRRig.enabled = false;
                GorillaTagger.Instance.offlineVRRig.transform.position = pointer.transform.position + new Vector3(0f, 0.5f, 1f);
                GorillaTagger.Instance.offlineVRRig.transform.LookAt(pointer.transform.position);
                GorillaTagger.Instance.offlineVRRig.head.rigTarget.LookAt(pointer.transform.position);
                GorillaTagger.Instance.offlineVRRig.head.rigTarget.transform.forward += Mods.RandomVector(10f);
                GorillaTagger.Instance.offlineVRRig.rightHand.rigTarget.position = GorillaTagger.Instance.offlineVRRig.transform.position + Mods.RandomVector(4f);
                GorillaTagger.Instance.offlineVRRig.leftHand.rigTarget.position = GorillaTagger.Instance.offlineVRRig.transform.position + Mods.RandomVector(4f);

            }, delegate { GorillaTagger.Instance.offlineVRRig.enabled = true; });
        }

        private static Vector3 RandomVector(float v)
        {
            throw new NotImplementedException();
        }

        public static void BatGun() // this mod is a bug gun
        {
            MakeGun(CurrentGunColor, new Vector3(0.15f, 0.15f, 0.15f), 0.025f, PrimitiveType.Sphere, GorillaLocomotion.Player.Instance.rightControllerTransform, true, delegate
            {
                GameObject.Find("Cave Bat Holdable").transform.position = pointer.transform.position + new Vector3(0f, 0.25f, 0f);
            }, delegate { });
        }
        public static void BubbleGunTest() // this mod is a bug gun
        {
            MakeGun(CurrentGunColor, new Vector3(0.15f, 0.15f, 0.15f), 0.025f, PrimitiveType.Sphere, GorillaLocomotion.Player.Instance.rightControllerTransform, true, delegate
            {
                GameObject.Find("UnderwaterBubbles").transform.position = pointer.transform.position + new Vector3(0f, 0.25f, 0f);
            }, delegate { });
        }
        public static void BecomeSkelly()
        {
            GorillaTagger.Instance.offlineVRRig.bodyRenderer.SetCosmeticBodyType(true ? GorillaBodyType.Skeleton : GorillaBodyType.Default);
        }

        public static void MuteAll()
        {
            foreach (GorillaPlayerScoreboardLine gorillaPlayerScoreboardLine in GorillaScoreboardTotalUpdater.allScoreboardLines)
            {
                GorillaPlayerScoreboardLine.MutePlayer(gorillaPlayerScoreboardLine.linePlayer.UserId, gorillaPlayerScoreboardLine.linePlayer.NickName, Mods.muteplayer ? 1 : 0);
            }
        }
        public static void AdminBadge(bool enable)
        {
            GameObject gameObject = GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/RigAnchor/rig/body/LBAAD.");
            gameObject.SetActive(enable);
        }
        public static void AntiAFK()
        {
            PhotonNetworkController.Instance.disableAFKKick = true;
        }

        public static void StartAllArcade()
        {
            foreach (ArcadeMachineButton arcadeMachineButton in GameObject.FindObjectsOfType<ArcadeMachineButton>())
            {
                arcadeMachineButton.Start();
                arcadeMachineButton.isOn = true;
            }
        }
        public static void BigBat()
        {
            GameObject.Find("Cave Bat Holdable").transform.localScale = new Vector3(5f, 5f, 5f);
        }
        public static void BigDoug()
        {
            GameObject.Find("Floating Bug Holdable").transform.localScale = new Vector3(5f, 5f, 5f);
        }
      
        public static void SplashR()
        {
            bool flag = ControllerInputPoller.instance.rightControllerIndexFloat > 0f;
            if (flag)
            {
                GorillaTagger.Instance.myVRRig.SendRPC("PlaySplashEffect", 0, new object[]
                {
                    GorillaTagger.Instance.rightHandTransform.position,
                    GorillaTagger.Instance.rightHandTransform.rotation,
                    4f,
                    100f,
                    true,
                    false
                });
            }
        }
        public static void SplashL()
        {
            bool flag = ControllerInputPoller.instance.leftControllerIndexFloat > 0f;
            if (flag)
            {
                GorillaTagger.Instance.myVRRig.SendRPC("PlaySplashEffect", 0, new object[]
                {
                    GorillaTagger.Instance.leftHandTransform.position,
                    GorillaTagger.Instance.leftHandTransform.rotation,
                    4f,
                    100f,
                    true,
                    false
                });
            }
        }






        public static void AntiReportNOWAYY()
        {
            foreach (GorillaPlayerScoreboardLine gorillaPlayerScoreboardLine in GorillaScoreboardTotalUpdater.allScoreboardLines)
            {
                bool flag = gorillaPlayerScoreboardLine.linePlayer == NetworkSystem.Instance.LocalPlayer;
                if (flag)
                {
                    Transform transform = gorillaPlayerScoreboardLine.reportButton.gameObject.transform;
                    foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
                    {
                        bool flag2 = !vrrig.isOfflineVRRig && !vrrig.isMyPlayer;
                        bool flag3 = flag2;
                        if (flag3)
                        {
                            float num = Vector3.Distance(vrrig.rightHandTransform.position, transform.position);
                            float num2 = Vector3.Distance(vrrig.leftHandTransform.position, transform.position);
                            float num3 = 0.75f;
                            bool flag4 = num < num3 || num2 < num3;
                            if (flag4)
                            {
                                PhotonNetwork.Disconnect();
                                Mods.RPCPROTECTION();
                            }
                        }
                    }
                }
            }
            Mods.RPCPROTECTION();
        }

        public static void RPCPROTECTION()
        {
            PhotonNetwork.MaxResendsBeforeDisconnect = int.MaxValue;
            GorillaNot.instance.rpcCallLimit = int.MaxValue;
            GorillaNot.instance.rpcErrorMax = int.MaxValue;
            GorillaNot.instance.logErrorMax = int.MaxValue;
            PhotonNetwork.CleanRpcBufferIfMine(Mods.skibidi(GorillaTagger.Instance.offlineVRRig));
            PhotonNetwork.OpCleanActorRpcBuffer(PhotonNetwork.LocalPlayer.ActorNumber);
            PhotonNetwork.OpCleanRpcBuffer(Mods.skibidi(GorillaTagger.Instance.offlineVRRig));
            PhotonNetwork.RemoveBufferedRPCs(GorillaTagger.Instance.myVRRig.ViewID, null, null);
            PhotonNetwork.RemoveBufferedRPCs(0, null, null);
            PhotonNetwork.RemoveRPCs(PhotonNetwork.LocalPlayer);
            PhotonNetwork.RemoveRPCsInGroup(int.MaxValue);
            PhotonNetwork.SendAllOutgoingCommands();
            GorillaNot.instance.OnPlayerLeftRoom(PhotonNetwork.LocalPlayer);
        }

        private static PhotonView skibidi(VRRig offlineVRRig)
        {
            throw new NotImplementedException();
        }

        public static void NoFingerMovement()
        {
            ControllerInputPoller.instance.leftControllerGripFloat = 0f;
            ControllerInputPoller.instance.rightControllerGripFloat = 0f;
            ControllerInputPoller.instance.leftControllerIndexFloat = 0f;
            ControllerInputPoller.instance.rightControllerIndexFloat = 0f;
            ControllerInputPoller.instance.leftControllerPrimaryButton = false;
            ControllerInputPoller.instance.leftControllerSecondaryButton = false;
            ControllerInputPoller.instance.rightControllerPrimaryButton = false;
            ControllerInputPoller.instance.rightControllerSecondaryButton = false;
        }


        public static void Invis()
        {
            if (right)
            {
                if (invisMonke)
                {
                    GorillaTagger.Instance.offlineVRRig.enabled = false;
                    GorillaTagger.Instance.offlineVRRig.transform.position = new Vector3(9999f, 9999f, 9999f);
                    DrawHandOrbs();
                }
                else
                {
                    GorillaTagger.Instance.offlineVRRig.enabled = true;
                }
                if (WristMenu.ybuttonDown && !lastHit2)
                {
                    invisMonke = !invisMonke;
                }
                lastHit2 = WristMenu.ybuttonDown;
            }
            else
            {
                if (invisMonke)
                {
                    GorillaTagger.Instance.offlineVRRig.enabled = false;
                    GorillaTagger.Instance.offlineVRRig.transform.position = new Vector3(9999f, 9999f, 9999f);
                    DrawHandOrbs();
                }
                else
                {
                    GorillaTagger.Instance.offlineVRRig.enabled = true;
                }
                if (WristMenu.bbuttonDown && !lastHit2)
                {
                    invisMonke = !invisMonke;
                }
                lastHit2 = WristMenu.bbuttonDown;
            }
        }
        #endregion
        #region Visual
        public static void Tracers()
        {
            foreach (Player p in PhotonNetwork.PlayerListOthers)
            {
                VRRig rig = RigShit.GetVRRigFromPlayer(p);
                GameObject g = new GameObject("Line");
                LineRenderer l = g.AddComponent<LineRenderer>();
                l.startWidth = 0.01f;
                l.endWidth = 0.01f;
                l.positionCount = 2;
                l.useWorldSpace = true;
                l.SetPosition(0, GorillaLocomotion.Player.Instance.rightControllerTransform.position);
                l.SetPosition(1, rig.transform.position);
                l.material.shader = Shader.Find("GUI/Text Shader");
                l.startColor = CurrentESPColor;
                l.endColor = CurrentESPColor;
                Destroy(l, Time.deltaTime);
            }
        }
        [Obsolete]
        public static void FPSboost()
        {
            fps = true;
            if (fps)
            {
                QualitySettings.masterTextureLimit = 999999999;
                QualitySettings.masterTextureLimit = 999999999;
                QualitySettings.globalTextureMipmapLimit = 999999999;
                QualitySettings.maxQueuedFrames = 60;
            }
        }

        [Obsolete]
        public static void fixFPS()
        {
            if (fps)
            {
                QualitySettings.masterTextureLimit = default;
                QualitySettings.masterTextureLimit = default;
                QualitySettings.globalTextureMipmapLimit = default;
                QualitySettings.maxQueuedFrames = default;
                fps = false;
            }
        }
        #endregion
        #region Save-Load Buttons & Settings
        public static void Save1()
        {
            List<string> list = new List<string>();
            foreach (ButtonInfo buttonInfo in WristMenu.CatButtons1)
            {
                bool? enabled = buttonInfo.enabled;
                bool flag = true;
                if (enabled.GetValueOrDefault() == flag & enabled != null)
                {
                    list.Add(buttonInfo.buttonText);
                }
            }
            foreach (ButtonInfo buttonInfo in WristMenu.CatButtons2)
            {
                bool? enabled = buttonInfo.enabled;
                bool flag = true;
                if (enabled.GetValueOrDefault() == flag & enabled != null)
                {
                    list.Add(buttonInfo.buttonText);
                }
            }
            foreach (ButtonInfo buttonInfo in WristMenu.CatButtons3)
            {
                bool? enabled = buttonInfo.enabled;
                bool flag = true;
                if (enabled.GetValueOrDefault() == flag & enabled != null)
                {
                    list.Add(buttonInfo.buttonText);
                }
            }
            foreach (ButtonInfo buttonInfo in WristMenu.CatButtons4)
            {
                bool? enabled = buttonInfo.enabled;
                bool flag = true;
                if (enabled.GetValueOrDefault() == flag & enabled != null)
                {
                    list.Add(buttonInfo.buttonText);
                }
            }
            foreach (ButtonInfo buttonInfo in WristMenu.CatButtons5)
            {
                bool? enabled = buttonInfo.enabled;
                bool flag = true;
                if (enabled.GetValueOrDefault() == flag & enabled != null)
                {
                    list.Add(buttonInfo.buttonText);
                }
            }
            foreach (ButtonInfo buttonInfo in WristMenu.CatButtons6)
            {
                bool? enabled = buttonInfo.enabled;
                bool flag = true;
                if (enabled.GetValueOrDefault() == flag & enabled != null)
                {
                    list.Add(buttonInfo.buttonText);
                }
            }
            foreach (ButtonInfo buttonInfo in WristMenu.CatButtons7)
            {
                bool? enabled = buttonInfo.enabled;
                bool flag = true;
                if (enabled.GetValueOrDefault() == flag & enabled != null)
                {
                    list.Add(buttonInfo.buttonText);
                }
            }
            foreach (ButtonInfo buttonInfo in WristMenu.CatButtons8)
            {
                bool? enabled = buttonInfo.enabled;
                bool flag = true;
                if (enabled.GetValueOrDefault() == flag & enabled != null)
                {
                    list.Add(buttonInfo.buttonText);
                }
            }
            foreach (ButtonInfo buttonInfo in WristMenu.CatButtons9)
            {
                bool? enabled = buttonInfo.enabled;
                bool flag = true;
                if (enabled.GetValueOrDefault() == flag & enabled != null)
                {
                    list.Add(buttonInfo.buttonText);
                }
            }
            foreach (ButtonInfo buttonInfo in WristMenu.CatButtons10)
            {
                bool? enabled = buttonInfo.enabled;
                bool flag = true;
                if (enabled.GetValueOrDefault() == flag & enabled != null)
                {
                    list.Add(buttonInfo.buttonText);
                }
            }
            File.WriteAllLines("Malachis_Temp\\Saved_Buttons.txt", list);
            NotifiLib.SendNotification("<color=white>[</color><color=blue>SAVE</color><color=white>]</color> <color=white>Saved Buttons Successfully!</color>");
        }
        public static void Load1()
        {
            string[] array = File.ReadAllLines("Malachis_Temp\\Saved_Buttons.txt");
            foreach (string b in array)
            {
                foreach (ButtonInfo buttonInfo in WristMenu.CatButtons1)
                {
                    if (buttonInfo.buttonText == b)
                    {
                        buttonInfo.enabled = new bool?(true);
                    }
                }
                foreach (ButtonInfo buttonInfo in WristMenu.CatButtons2)
                {
                    if (buttonInfo.buttonText == b)
                    {
                        buttonInfo.enabled = new bool?(true);
                    }
                }
                foreach (ButtonInfo buttonInfo in WristMenu.CatButtons3)
                {
                    if (buttonInfo.buttonText == b)
                    {
                        buttonInfo.enabled = new bool?(true);
                    }
                }
                foreach (ButtonInfo buttonInfo in WristMenu.CatButtons4)
                {
                    if (buttonInfo.buttonText == b)
                    {
                        buttonInfo.enabled = new bool?(true);
                    }
                }
                foreach (ButtonInfo buttonInfo in WristMenu.CatButtons5)
                {
                    if (buttonInfo.buttonText == b)
                    {
                        buttonInfo.enabled = new bool?(true);
                    }
                }
                foreach (ButtonInfo buttonInfo in WristMenu.CatButtons6)
                {
                    if (buttonInfo.buttonText == b)
                    {
                        buttonInfo.enabled = new bool?(true);
                    }
                }
                foreach (ButtonInfo buttonInfo in WristMenu.CatButtons7)
                {
                    if (buttonInfo.buttonText == b)
                    {
                        buttonInfo.enabled = new bool?(true);
                    }
                }
                foreach (ButtonInfo buttonInfo in WristMenu.CatButtons8)
                {
                    if (buttonInfo.buttonText == b)
                    {
                        buttonInfo.enabled = new bool?(true);
                    }
                }
                foreach (ButtonInfo buttonInfo in WristMenu.CatButtons9)
                {
                    if (buttonInfo.buttonText == b)
                    {
                        buttonInfo.enabled = new bool?(true);
                    }
                }
                foreach (ButtonInfo buttonInfo in WristMenu.CatButtons10)
                {
                    if (buttonInfo.buttonText == b)
                    {
                        buttonInfo.enabled = new bool?(true);
                    }
                }
            }
            NotifiLib.SendNotification("<color=white>[</color><color=blue>LOAD</color><color=white>]</color> <color=white>Loaded Buttons Successfully!</color>");
        }
        public static void Save()
        {
            List<string> list = new List<string>();
            foreach (ButtonInfo buttonInfo in WristMenu.settingsbuttons)
            {
                bool? enabled = buttonInfo.enabled;
                bool flag = true;
                if (enabled.GetValueOrDefault() == flag & enabled != null && buttonInfo.buttonText != "Save Settings")
                {
                    list.Add(buttonInfo.buttonText);
                }
            }
            File.WriteAllLines("Malachis_Temp\\Saved_Settings.txt", list);
            string text4 = string.Concat(new string[]
            {
               change1.ToString(),
               "\n",
               change2.ToString(),
               "\n",
               change3.ToString(),
               "\n",
               change4.ToString(),
               "\n",
               change6.ToString(),
               "\n",
               change7.ToString(),
               "\n",
               change8.ToString(),
               "\n",
               change9.ToString(),
               "\n",
               change10.ToString(),
               "\n",
               change11.ToString(),
               "\n",
               change12.ToString(),
               "\n",
               change13.ToString(),
               "\n",
               change14.ToString(),
               "\n",
               change15.ToString(),
               "\n",
               change16.ToString()
            });
            File.WriteAllText("Malachis_Temp/Saved_Settings2.txt", text4.ToString());
            NotifiLib.SendNotification("<color=white>[</color><color=blue>SAVE</color><color=white>]</color> <color=white>Saved Settings Successfully!</color>");
        }
        public static void Load()
        {
            string[] array = File.ReadAllLines("Malachis_Temp\\Saved_Settings.txt");
            foreach (string b in array)
            {
                foreach (ButtonInfo buttonInfo in WristMenu.settingsbuttons)
                {
                    if (buttonInfo.buttonText == b)
                    {
                        buttonInfo.enabled = new bool?(true);
                    }
                }
            }
            try
            {
                string text3 = File.ReadAllText("Malachis_Temp/Saved_Settings2.txt");
                string[] array4 = text3.Split(new string[] { "\n" }, StringSplitOptions.None);
                change1 = int.Parse(array4[0]) - 1;
                Changeplat();
                change2 = int.Parse(array4[1]) - 1;
                Changenoti();
                change3 = int.Parse(array4[2]) - 1;
                ChangeFPS();
                change4 = int.Parse(array4[3]) - 1;
                Changedisconnect();
                change6 = int.Parse(array4[4]) - 1;
                Changemenu();
                change7 = int.Parse(array4[5]) - 1;
                Changepagebutton();
                change8 = int.Parse(array4[6]) - 1;
                ChangeOrbColor();
                change9 = int.Parse(array4[7]) - 1;
                ChangeVisualColor();
                change10 = int.Parse(array4[8]) - 1;
                ThemeChangerV1();
                change11 = int.Parse(array4[9]) - 1;
                ThemeChangerV2();
                change12 = int.Parse(array4[10]) - 1;
                ThemeChangerV3();
                change13 = int.Parse(array4[11]) - 1;
                ThemeChangerV4();
                change14 = int.Parse(array4[12]) - 1;
                ThemeChangerV5();
                change15 = int.Parse(array4[13]) - 1;
                ThemeChangerV6();
                change16 = int.Parse(array4[14]) - 1;
                ThemeChangerV7();
            }
            catch
            {
            }
            NotifiLib.SendNotification("<color=white>[</color><color=blue>LOAD</color><color=white>]</color> <color=white>Loaded settings successfully!</color>");
        }
        #endregion
        #region Platform Shit
        // sticky plats r broke still srry
        private static void PlatformsThing(bool invis, bool sticky)
        {
            if (TriggerPlats)
            {
                RPlat = WristMenu.triggerDownR;
                LPlat = WristMenu.triggerDownL;
            }
            else
            {
                RPlat = WristMenu.gripDownR;
                LPlat = WristMenu.gripDownL;
            }
            if (RPlat)
            {
                if (!once_right && jump_right_local == null)
                {
                    if (sticky)
                    {
                        jump_right_local = GameObject.CreatePrimitive(0);
                    }
                    else
                    {
                        jump_right_local = GameObject.CreatePrimitive((PrimitiveType)3);
                    }
                    if (invis)
                    {
                        Destroy(jump_right_local.GetComponent<Renderer>());
                    }
                    jump_right_local.transform.localScale = scale;
                    jump_right_local.transform.position = new Vector3(0f, -0.01f, 0f) + GorillaLocomotion.Player.Instance.rightControllerTransform.position;
                    jump_right_local.transform.rotation = GorillaLocomotion.Player.Instance.rightControllerTransform.rotation;
                    jump_right_local.AddComponent<GorillaSurfaceOverride>().overrideIndex = jump_right_local.GetComponent<GorillaSurfaceOverride>().overrideIndex;
                    object[] array1 = new object[]
                    {
                        new Vector3(0f, -0.01f, 0f) + GorillaLocomotion.Player.Instance.rightControllerTransform.position,
                        GorillaLocomotion.Player.Instance.rightControllerTransform.rotation
                    };
                    once_right = true;
                    once_right_false = false;
                    ColorChanger colorChanger1 = jump_right_local.AddComponent<ColorChanger>();
                    colorChanger1.colors = new Gradient
                    {
                        colorKeys = colorKeysPlatformMonke
                    };
                    colorChanger1.Start();
                }
            }
            else
            {
                if (!once_right_false && jump_right_local != null)
                {
                    Destroy(jump_right_local.GetComponent<Collider>());
                    Rigidbody platr = jump_right_local.AddComponent(typeof(Rigidbody)) as Rigidbody;
                    platr.velocity = GorillaLocomotion.Player.Instance.rightHandCenterVelocityTracker.GetAverageVelocity(true, 5);
                    Destroy(jump_right_local, 2.0f);
                    jump_right_local = null;
                    once_right = false;
                    once_right_false = true;
                }
            }
            if (LPlat)
            {
                if (!once_left && jump_left_local == null)
                {
                    if (sticky)
                    {
                        jump_left_local = GameObject.CreatePrimitive(0);
                    }
                    else
                    {
                        jump_left_local = GameObject.CreatePrimitive((PrimitiveType)3);
                    }
                    if (invis)
                    {
                        Destroy(jump_left_local.GetComponent<Renderer>());
                    }
                    jump_left_local.transform.localScale = scale;
                    jump_left_local.transform.position = new Vector3(0f, -0.01f, 0f) + GorillaLocomotion.Player.Instance.leftControllerTransform.position;
                    jump_left_local.transform.rotation = GorillaLocomotion.Player.Instance.leftControllerTransform.rotation;
                    jump_left_local.AddComponent<GorillaSurfaceOverride>().overrideIndex = jump_left_local.GetComponent<GorillaSurfaceOverride>().overrideIndex;
                    object[] array2 = new object[]
                    {
                        new Vector3(0f, -0.01f, 0f) + GorillaLocomotion.Player.Instance.leftControllerTransform.position,
                        GorillaLocomotion.Player.Instance.leftControllerTransform.rotation
                    };
                    once_left = true;
                    once_left_false = false;
                    ColorChanger colorChanger2 = jump_left_local.AddComponent<ColorChanger>();
                    colorChanger2.colors = new Gradient
                    {
                        colorKeys = colorKeysPlatformMonke
                    };
                    colorChanger2.Start();
                }
            }
            else
            {
                if (!once_left_false && jump_left_local != null)
                {
                    Destroy(jump_left_local.GetComponent<Collider>());
                    Rigidbody comp = jump_left_local.AddComponent(typeof(Rigidbody)) as Rigidbody;
                    comp.velocity = GorillaLocomotion.Player.Instance.leftHandCenterVelocityTracker.GetAverageVelocity(true, 5);
                    Destroy(jump_left_local, 2.0f);
                    jump_left_local = null;
                    once_left = false;
                    once_left_false = true;
                }
            }
            if (!PhotonNetwork.InRoom)
            {
                for (int i = 0; i < jump_right_network.Length; i++)
                {
                    Destroy(jump_right_network[i]);
                }
                for (int j = 0; j < jump_left_network.Length; j++)
                {
                    Destroy(jump_left_network[j]);
                }
            }
        }
#endregion
        #region GetButton
        public static ButtonInfo GetButton(string name)
        {
            foreach (ButtonInfo b in WristMenu.buttons)
            {
                if (b.buttonText == name)
                {
                    return b;
                }
            }
            foreach (ButtonInfo b in WristMenu.settingsbuttons)
            {
                if (b.buttonText == name)
                {
                    return b;
                }
            }
            foreach (ButtonInfo b in WristMenu.CatButtons1)
            {
                if (b.buttonText == name)
                {
                    return b;
                }
            }
            foreach (ButtonInfo b in WristMenu.CatButtons2)
            {
                if (b.buttonText == name)
                {
                    return b;
                }
            }
            foreach (ButtonInfo b in WristMenu.CatButtons3)
            {
                if (b.buttonText == name)
                {
                    return b;
                }
            }
            foreach (ButtonInfo b in WristMenu.CatButtons4)
            {
                if (b.buttonText == name)
                {
                    return b;
                }
            }
            foreach (ButtonInfo b in WristMenu.CatButtons5)
            {
                if (b.buttonText == name)
                {
                    return b;
                }
            }
            foreach (ButtonInfo b in WristMenu.CatButtons6)
            {
                if (b.buttonText == name)
                {
                    return b;
                }
            }
            foreach (ButtonInfo b in WristMenu.CatButtons7)
            {
                if (b.buttonText == name)
                {
                    return b;
                }
            }
            foreach (ButtonInfo b in WristMenu.CatButtons8)
            {
                if (b.buttonText == name)
                {
                    return b;
                }
            }
            foreach (ButtonInfo b in WristMenu.CatButtons9)
            {
                if (b.buttonText == name)
                {
                    return b;
                }
            }
            foreach (ButtonInfo b in WristMenu.CatButtons10)
            {
                if (b.buttonText == name)
                {
                    return b;
                }
            }
            return null;
        }
        #endregion
        #region Category shit
        public static void Settings()
        {
            WristMenu.settingsbuttons[0].enabled = new bool?(false);
            WristMenu.buttons[2].enabled = new bool?(false);
            inSettings = !inSettings;
            if (inSettings)
            {
                WristMenu.pageNumber = 0;
            }
            if (!inSettings)
            {
                WristMenu.pageNumber = 0;
            }
            WristMenu.DestroyMenu();
            WristMenu.instance.Draw();
        }
        public static void Cat1()
        {
            WristMenu.CatButtons1[0].enabled = new bool?(false);
            WristMenu.buttons[3].enabled = new bool?(false);
            inCat1 = !inCat1;
            if (inCat1)
            {
                WristMenu.pageNumber = 0;
            }
            if (change7 == 1)
            {
                if (!inCat1)
                {
                    WristMenu.pageNumber = 1;
                }
            }
            if (change7 == 2 | change7 == 3 | change7 == 4 | change7 == 5)
            {
                if (!inCat1)
                {
                    WristMenu.pageNumber = 0;
                }
            }
            WristMenu.DestroyMenu();
            WristMenu.instance.Draw();
        }
        public static void Cat2()
        {
            WristMenu.CatButtons2[0].enabled = new bool?(false);
            WristMenu.buttons[4].enabled = new bool?(false);
            inCat2 = !inCat2;
            if (inCat2)
            {
                WristMenu.pageNumber = 0;
            }
            if (change7 == 1)
            {
                if (!inCat2)
                {
                    WristMenu.pageNumber = 1;
                }
            }
            if (change7 == 2 | change7 == 3 | change7 == 4 | change7 == 5)
            {
                if (!inCat2)
                {
                    WristMenu.pageNumber = 0;
                }
            }
            WristMenu.DestroyMenu();
            WristMenu.instance.Draw();
        }
        public static void Cat3()
        {
            WristMenu.CatButtons3[0].enabled = new bool?(false);
            WristMenu.buttons[5].enabled = new bool?(false);
            inCat3 = !inCat3;
            if (inCat3)
            {
                WristMenu.pageNumber = 0;
            }
            if (change7 == 1)
            {
                if (!inCat3)
                {
                    WristMenu.pageNumber = 1;
                }
            }
            if (change7 == 2 | change7 == 3 | change7 == 4 | change7 == 5)
            {
                if (!inCat3)
                {
                    WristMenu.pageNumber = 1;
                }
            }
            WristMenu.DestroyMenu();
            WristMenu.instance.Draw();
        }
        public static void Cat4()
        {
            WristMenu.CatButtons4[0].enabled = new bool?(false);
            WristMenu.buttons[6].enabled = new bool?(false);
            inCat4 = !inCat4;
            if (inCat4)
            {
                WristMenu.pageNumber = 0;
            }
            if (change7 == 1)
            {
                if (!inCat4)
                {
                    WristMenu.pageNumber = 1;
                }
            }
            if (change7 == 2 | change7 == 3 | change7 == 4 | change7 == 5)
            {
                if (!inCat4)
                {
                    WristMenu.pageNumber = 1;
                }
            }
            WristMenu.DestroyMenu();
            WristMenu.instance.Draw();
        }
        public static void Cat5()
        {
            WristMenu.CatButtons5[0].enabled = new bool?(false);
            WristMenu.buttons[7].enabled = new bool?(false);
            inCat5 = !inCat5;
            if (inCat5)
            {
                WristMenu.pageNumber = 0;
            }
            if (change7 == 1)
            {
                if (!inCat5)
                {
                    WristMenu.pageNumber = 2;
                }
            }
            if (change7 == 2 | change7 == 3 | change7 == 4 | change7 == 5)
            {
                if (!inCat5)
                {
                    WristMenu.pageNumber = 1;
                }
            }
            WristMenu.DestroyMenu();
            WristMenu.instance.Draw();
        }
        public static void Cat6()
        {
            WristMenu.CatButtons6[0].enabled = new bool?(false);
            WristMenu.buttons[8].enabled = new bool?(false);
            inCat6 = !inCat6;
            if (inCat6)
            {
                WristMenu.pageNumber = 0;
            }
            if (change7 == 1)
            {
                if (!inCat6)
                {
                    WristMenu.pageNumber = 2;
                }
            }
            if (change7 == 2 | change7 == 3 | change7 == 4 | change7 == 5)
            {
                if (!inCat6)
                {
                    WristMenu.pageNumber = 1;
                }
            }
            WristMenu.DestroyMenu();
            WristMenu.instance.Draw();
        }
        public static void Cat7()
        {
            WristMenu.CatButtons7[0].enabled = new bool?(false);
            WristMenu.buttons[9].enabled = new bool?(false);
            inCat7 = !inCat7;
            if (inCat7)
            {
                WristMenu.pageNumber = 0;
            }
            if (change7 == 1)
            {
                if (!inCat7)
                {
                    WristMenu.pageNumber = 2;
                }
            }
            if (change7 == 2 | change7 == 3 | change7 == 4 | change7 == 5)
            {
                if (!inCat7)
                {
                    WristMenu.pageNumber = 1;
                }
            }
            WristMenu.DestroyMenu();
            WristMenu.instance.Draw();
        }
        public static void Cat8()
        {
            WristMenu.CatButtons8[0].enabled = new bool?(false);
            WristMenu.buttons[10].enabled = new bool?(false);
            inCat8 = !inCat8;
            if (inCat8)
            {
                WristMenu.pageNumber = 0;
            }
            if (change7 == 1)
            {
                if (!inCat8)
                {
                    WristMenu.pageNumber = 2;
                }
            }
            if (change7 == 2 | change7 == 3 | change7 == 4 | change7 == 5)
            {
                if (!inCat8)
                {
                    WristMenu.pageNumber = 1;
                }
            }
            WristMenu.DestroyMenu();
            WristMenu.instance.Draw();
        }
        public static void Cat9()
        {
            WristMenu.CatButtons9[0].enabled = new bool?(false);
            WristMenu.buttons[11].enabled = new bool?(false);
            inCat9 = !inCat9;
            if (inCat9)
            {
                WristMenu.pageNumber = 0;
            }
            if (change7 == 1)
            {
                if (!inCat9)
                {
                    WristMenu.pageNumber = 2;
                }
            }
            if (change7 == 2 | change7 == 3 | change7 == 4 | change7 == 5)
            {
                if (!inCat9)
                {
                    WristMenu.pageNumber = 2;
                }
            }
            WristMenu.DestroyMenu();
            WristMenu.instance.Draw();
        }
        public static void Cat10()
        {
            WristMenu.CatButtons10[0].enabled = new bool?(false);
            WristMenu.buttons[12].enabled = new bool?(false);
            inCat10 = !inCat10;
            if (inCat10)
            {
                WristMenu.pageNumber = 0;
            }
            if (change7 == 1)
            {
                if (!inCat10)
                {
                    WristMenu.pageNumber = 3;
                }
            }
            if (change7 == 2 | change7 == 3 | change7 == 4 | change7 == 5)
            {
                if (!inCat10)
                {
                    WristMenu.pageNumber = 2;
                }
            }
            WristMenu.DestroyMenu();
            WristMenu.instance.Draw();
        }
        #endregion
        #region Changers
        // DO NOT MESS WITH ANY OF THE THEME CHANGERS OR CHANGERS
        public static void Changeplat()
        {
            change1++;
            if (change1 > 2)
            {
                change1 = 1;
            }
            if (change1 == 1)
            {
                TriggerPlats = false;
                NotifiLib.SendNotification("<color=white>[</color><color=blue>PLATFORMS</color><color=white>] Enable Platforms: Grips</color>");
            }
            if (change1 == 2)
            {
                TriggerPlats = true;
                NotifiLib.SendNotification("<color=white>[</color><color=blue>PLATFORMS</color><color=white>] Enable Platforms: Triggers</color>");
            }
        }
        public static void Changenoti()
        {
            change2++;
            if (change2 > 2)
            {
                change2 = 1;
            }
            if (change2 == 1)
            {
                NotifiLib.IsEnabled = true;
                NotifiLib.SendNotification("<color=white>[</color><color=blue>NOTIS</color><color=white>] Notis Enabled: Yes</color>");
            }
            if (change2 == 2)
            {
                NotifiLib.SendNotification("<color=white>[</color><color=blue>NOTIS</color><color=white>] Notis Enabled: No</color>");
                NotifiLib.IsEnabled = false;
            }
        }
        public static void ChangeFPS()
        {
            change3++;
            if (change3 > 2)
            {
                change3 = 1;
            }
            if (change3 == 1)
            {
                FPSPage = false;
                NotifiLib.SendNotification("<color=white>[</color><color=blue>FPS & PAGE COUNTER</color><color=white>] Is Enabled: No</color>");
            }
            if (change3 == 2)
            {
                FPSPage = true;
                NotifiLib.SendNotification("<color=white>[</color><color=blue>FPS & PAGE COUNTER</color><color=white>] Is Enabled: Yes</color>");
            }
        }
        public static void Changedisconnect()
        {
            change4++;
            if (change4 > 4)
            {
                change4 = 1;
            }
            if (change4 == 1)
            {
                NotifiLib.SendNotification("<color=white>[</color><color=blue>DISCONNECT BUTTON</color><color=white>] Disconnect Location: Right Side</color>");
            }
            if (change4 == 2)
            {
                NotifiLib.SendNotification("<color=white>[</color><color=blue>DISCONNECT BUTTON</color><color=white>] Disconnect Location: Left Side</color>");
            }
            if (change4 == 3)
            {
                NotifiLib.SendNotification("<color=white>[</color><color=blue>DISCONNECT BUTTON</color><color=white>] Disconnect Location: Top</color>");
            }
            if (change4 == 4)
            {
                NotifiLib.SendNotification("<color=white>[</color><color=blue>DISCONNECT BUTTON</color><color=white>] Disconnect Location: Bottom</color>");
            }
        }
        public static void Changemenu()
        {
            change6++;
            if (change6 > 2)
            {
                change6 = 1;
            }
            if (change6 == 1)
            {
                right = false;
                NotifiLib.SendNotification("<color=white>[</color><color=blue>MENU LOCATION</color><color=white>] Current Location: Left Hand</color>");
            }
            if (change6 == 2)
            {
                right = true;
                NotifiLib.SendNotification("<color=white>[</color><color=blue>MENU LOCATION</color><color=white>] Current Location: Right Hand</color>");
            }
        }
        public static void Changepagebutton()
        {
            change7++;
            if (change7 > 5)
            {
                change7 = 1;
            }
            if (change7 == 1)
            {
                NotifiLib.SendNotification("<color=white>[</color><color=blue>NEXT & PREV</color><color=white>] Page Change Button Location: On Menu</color>");
            }
            if (change7 == 2)
            {
                NotifiLib.SendNotification("<color=white>[</color><color=blue>NEXT & PREV</color><color=white>] Page Change Button Location: Top</color>");
            }
            if (change7 == 3)
            {
                NotifiLib.SendNotification("<color=white>[</color><color=blue>NEXT & PREV</color><color=white>] Page Change Button Location: Sides</color>");
            }
            if (change7 == 4)
            {
                NotifiLib.SendNotification("<color=white>[</color><color=blue>NEXT & PREV</color><color=white>] Page Change Button Location: Bottom</color>");
            }
            if (change7 == 5)
            {
                NotifiLib.SendNotification("<color=white>[</color><color=blue>NEXT & PREV</color><color=white>] Page Change Button Location: Triggers</color>");
            }
        }
        public static void ChangeOrbColor()
        {
            change8++;
            if (change8 > 9)
            {
                change8 = 1;
            }
            if (change8 == 1)
            {
                CurrentGunColor = Color.blue;
                NotifiLib.SendNotification("<color=white>[</color><color=blue>GUN & HAND ORB COLOR</color><color=white>] Current Color: Blue</color>");
            }
            if (change8 == 2)
            {
                CurrentGunColor = Color.red;
                NotifiLib.SendNotification("<color=white>[</color><color=blue>GUN & HAND ORB COLOR</color><color=white>] Current Color: Red</color>");
            }
            if (change8 == 3)
            {
                CurrentGunColor = Color.white;
                NotifiLib.SendNotification("<color=white>[</color><color=blue>GUN & HAND ORB COLOR</color><color=white>] Current Color: White</color>");
            }
            if (change8 == 4)
            {
                CurrentGunColor = Color.green;
                NotifiLib.SendNotification("<color=white>[</color><color=blue>GUN & HAND ORB COLOR</color><color=white>] Current Color: Green</color>");
            }
            if (change8 == 5)
            {
                CurrentGunColor = Color.magenta;
                NotifiLib.SendNotification("<color=white>[</color><color=blue>GUN & HAND ORB COLOR</color><color=white>] Current Color: Magenta</color>");
            }
            if (change8 == 6)
            {
                CurrentGunColor = Color.cyan;
                NotifiLib.SendNotification("<color=white>[</color><color=blue>GUN & HAND ORB COLOR</color><color=white>] Current Color: Cyan</color>");
            }
            if (change8 == 7)
            {
                CurrentGunColor = Color.yellow;
                NotifiLib.SendNotification("<color=white>[</color><color=blue>GUN & HAND ORB COLOR</color><color=white>] Current Color: Yellow</color>");
            }
            if (change8 == 8)
            {
                CurrentGunColor = Color.black;
                NotifiLib.SendNotification("<color=white>[</color><color=blue>GUN & HAND ORB COLOR</color><color=white>] Current Color: Black</color>");
            }
            if (change8 == 9)
            {
                CurrentGunColor = Color.grey;
                NotifiLib.SendNotification("<color=white>[</color><color=blue>GUN & HAND ORB COLOR</color><color=white>] Current Color: Grey</color>");
            }
        }
        public static void ChangeVisualColor()
        {
            change9++;
            if (change9 > 9)
            {
                change9 = 1;
            }
            if (change9 == 1)
            {
                CurrentESPColor = Color.blue;
                NotifiLib.SendNotification("<color=white>[</color><color=blue>ESP COLOR</color><color=white>] Current Color: Blue</color>");
            }
            if (change9 == 2)
            {
                CurrentESPColor = Color.red;
                NotifiLib.SendNotification("<color=white>[</color><color=blue>ESP COLOR</color><color=white>] Current Color: Red</color>");
            }
            if (change9 == 3)
            {
                CurrentESPColor = Color.white;
                NotifiLib.SendNotification("<color=white>[</color><color=blue>ESP COLOR</color><color=white>] Current Color: White</color>");
            }
            if (change9 == 4)
            {
                CurrentESPColor = Color.green;
                NotifiLib.SendNotification("<color=white>[</color><color=blue>ESP COLOR</color><color=white>] Current Color: Green</color>");
            }
            if (change9 == 5)
            {
                CurrentESPColor = Color.magenta;
                NotifiLib.SendNotification("<color=white>[</color><color=blue>ESP COLOR</color><color=white>] Current Color: Magenta</color>");
            }
            if (change9 == 6)
            {
                CurrentESPColor = Color.cyan;
                NotifiLib.SendNotification("<color=white>[</color><color=blue>ESP COLOR</color><color=white>] Current Color: Cyan</color>");
            }
            if (change9 == 7)
            {
                CurrentESPColor = Color.yellow;
                NotifiLib.SendNotification("<color=white>[</color><color=blue>ESP COLOR</color><color=white>] Current Color: Yellow</color>");
            }
            if (change9 == 8)
            {
                CurrentESPColor = Color.black;
                NotifiLib.SendNotification("<color=white>[</color><color=blue>ESP COLOR</color><color=white>] Current Color: Black</color>");
            }
            if (change9 == 9)
            {
                CurrentESPColor = Color.grey;
                NotifiLib.SendNotification("<color=white>[</color><color=blue>ESP COLOR</color><color=white>] Current Color: Grey</color>");
            }
        }
        public static void ThemeChangerV1()
        {
            change10++;
            if (change10 > 11)
            {
                change10 = 1;
            }
            if (change10 == 1)
            {
                if (WristMenu.ChangingColors)
                {
                    RGBMenu = false;
                    WristMenu.FirstColor = Color.blue;
                    NotifiLib.SendNotification("<color=white>[</color><color=blue>THEME CHANGER</color><color=white>] First Color: Blue</color>");
                }
                else
                {
                    RGBMenu = false;
                    WristMenu.NormalColor = Color.blue;
                    NotifiLib.SendNotification("<color=white>[</color><color=blue>THEME CHANGER</color><color=white>] Menu Color: Blue</color>");
                }
            }
            if (change10 == 2)
            {
                if (WristMenu.ChangingColors)
                {
                    WristMenu.FirstColor = Color.red;
                    NotifiLib.SendNotification("<color=white>[</color><color=blue>THEME CHANGER</color><color=white>] First Color: Red</color>");
                }
                else
                {
                    WristMenu.NormalColor = Color.red;
                    NotifiLib.SendNotification("<color=white>[</color><color=blue>THEME CHANGER</color><color=white>] Menu Color: Red</color>");
                }
            }
            if (change10 == 3)
            {
                if (WristMenu.ChangingColors)
                {
                    WristMenu.FirstColor = Color.white;
                    NotifiLib.SendNotification("<color=white>[</color><color=blue>THEME CHANGER</color><color=white>] First Color: White</color>");
                }
                else
                {
                    WristMenu.NormalColor = Color.white;
                    NotifiLib.SendNotification("<color=white>[</color><color=blue>THEME CHANGER</color><color=white>] Menu Color: White</color>");
                }
            }
            if (change10 == 4)
            {
                if (WristMenu.ChangingColors)
                {
                    WristMenu.FirstColor = Color.green;
                    NotifiLib.SendNotification("<color=white>[</color><color=blue>THEME CHANGER</color><color=white>] First Color: Green</color>");
                }
                else
                {
                    WristMenu.NormalColor = Color.green;
                    NotifiLib.SendNotification("<color=white>[</color><color=blue>THEME CHANGER</color><color=white>] Menu Color: Green</color>");
                }
            }
            if (change10 == 5)
            {
                if (WristMenu.ChangingColors)
                {
                    WristMenu.FirstColor = Color.magenta;
                    NotifiLib.SendNotification("<color=white>[</color><color=blue>THEME CHANGER</color><color=white>] First Color: Magenta</color>");
                }
                else
                {
                    WristMenu.NormalColor = Color.magenta;
                    NotifiLib.SendNotification("<color=white>[</color><color=blue>THEME CHANGER</color><color=white>] Menu Color: Magenta</color>");
                }
            }
            if (change10 == 6)
            {
                if (WristMenu.ChangingColors)
                {
                    WristMenu.FirstColor = Color.cyan;
                    NotifiLib.SendNotification("<color=white>[</color><color=blue>THEME CHANGER</color><color=white>] First Color: Cyan</color>");
                }
                else
                {
                    WristMenu.NormalColor = Color.cyan;
                    NotifiLib.SendNotification("<color=white>[</color><color=blue>THEME CHANGER</color><color=white>] Menu Color: Cyan</color>");
                }
            }
            if (change10 == 7)
            {
                if (WristMenu.ChangingColors)
                {
                    WristMenu.FirstColor = Color.yellow;
                    NotifiLib.SendNotification("<color=white>[</color><color=blue>THEME CHANGER</color><color=white>] First Color: Yellow</color>");
                }
                else
                {
                    WristMenu.NormalColor = Color.yellow;
                    NotifiLib.SendNotification("<color=white>[</color><color=blue>THEME CHANGER</color><color=white>] Menu Color: Yellow</color>");
                }
            }
            if (change10 == 8)
            {
                if (WristMenu.ChangingColors)
                {
                    WristMenu.FirstColor = Color.black;
                    NotifiLib.SendNotification("<color=white>[</color><color=blue>THEME CHANGER</color><color=white>] First Color: Black</color>");
                }
                else
                {
                    WristMenu.NormalColor = Color.black;
                    NotifiLib.SendNotification("<color=white>[</color><color=blue>THEME CHANGER</color><color=white>] Menu Color: Black</color>");
                }
            }
            if (change10 == 9)
            {
                if (WristMenu.ChangingColors)
                {
                    WristMenu.FirstColor = Color.grey;
                    NotifiLib.SendNotification("<color=white>[</color><color=blue>THEME CHANGER</color><color=white>] First Color: Grey</color>");
                }
                else
                {
                    WristMenu.NormalColor = Color.grey;
                    NotifiLib.SendNotification("<color=white>[</color><color=blue>THEME CHANGER</color><color=white>] Menu Color: Grey</color>");
                }
            }
            if (change10 == 10)
            {
                NotifiLib.SendNotification("<color=white>[</color><color=blue>THEME CHANGER</color><color=white>] Menu Color: Clear</color>");
            }
            if (change10 == 11)
            {
                if (WristMenu.ChangingColors)
                {
                    RGBMenu = true;
                    NotifiLib.SendNotification("<color=white>[</color><color=blue>THEME CHANGER</color><color=white>] Menu Color: RGB</color>");
                }
                else
                {
                    NotifiLib.SendNotification("<color=white>[</color><color=red>ERROR</color><color=white>] Cannot Change The Menu To RGB Due To WristMenu.ChangingColors Being false</color>");
                }
            }
        }
        public static void ThemeChangerV2()
        {
            change11++;
            if (change11 > 9)
            {
                change11 = 1;
            }
            if (change11 == 1)
            {
                WristMenu.SecondColor = Color.black;
                NotifiLib.SendNotification("<color=white>[</color><color=blue>THEME CHANGER</color><color=white>] Second Color: Black</color>");
            }
            if (change11 == 2)
            {
                WristMenu.SecondColor = Color.red;
                NotifiLib.SendNotification("<color=white>[</color><color=blue>THEME CHANGER</color><color=white>] Second Color: Red</color>");
            }
            if (change11 == 3)
            {
                WristMenu.SecondColor = Color.white;
                NotifiLib.SendNotification("<color=white>[</color><color=blue>THEME CHANGER</color><color=white>] Second Color: White</color>");
            }
            if (change11 == 4)
            {
                WristMenu.SecondColor = Color.green;
                NotifiLib.SendNotification("<color=white>[</color><color=blue>THEME CHANGER</color><color=white>] Second Color: Green</color>");
            }
            if (change11 == 5)
            {
                WristMenu.SecondColor = Color.magenta;
                NotifiLib.SendNotification("<color=white>[</color><color=blue>THEME CHANGER</color><color=white>] Second Color: Magenta</color>");
            }
            if (change11 == 6)
            {
                WristMenu.SecondColor = Color.cyan;
                NotifiLib.SendNotification("<color=white>[</color><color=blue>THEME CHANGER</color><color=white>] Second Color: Cyan</color>");
            }
            if (change11 == 7)
            {
                WristMenu.SecondColor = Color.yellow;
                NotifiLib.SendNotification("<color=white>[</color><color=blue>THEME CHANGER</color><color=white>] Second Color: Yellow</color>");
            }
            if (change11 == 8)
            {
                WristMenu.SecondColor = Color.blue;
                NotifiLib.SendNotification("<color=white>[</color><color=blue>THEME CHANGER</color><color=white>] Second Color: Blue</color>");
            }
            if (change11 == 9)
            {
                WristMenu.SecondColor = Color.grey;
                NotifiLib.SendNotification("<color=white>[</color><color=blue>THEME CHANGER</color><color=white>] Second Color: Grey</color>");
            }
        }
        public static void ThemeChangerV3()
        {
            change12++;
            if (change12 > 10)
            {
                change12 = 1;
            }
            if (change12 == 1)
            {
                WristMenu.ButtonColorDisable = Color.yellow;
                NotifiLib.SendNotification("<color=white>[</color><color=blue>THEME CHANGER</color><color=white>] Disable Button Color: Yellow</color>");
            }
            if (change12 == 2)
            {
                WristMenu.ButtonColorDisable = Color.red;
                NotifiLib.SendNotification("<color=white>[</color><color=blue>THEME CHANGER</color><color=white>] Disable Button Color: Red</color>");
            }
            if (change12 == 3)
            {
                WristMenu.ButtonColorDisable = Color.white;
                NotifiLib.SendNotification("<color=white>[</color><color=blue>THEME CHANGER</color><color=white>] Disable Button Color: White</color>");
            }
            if (change12 == 4)
            {
                WristMenu.ButtonColorDisable = Color.green;
                NotifiLib.SendNotification("<color=white>[</color><color=blue>THEME CHANGER</color><color=white>] Disable Button Color: Green</color>");
            }
            if (change12 == 5)
            {
                WristMenu.ButtonColorDisable = Color.magenta;
                NotifiLib.SendNotification("<color=white>[</color><color=blue>THEME CHANGER</color><color=white>] Disable Button Color: Magenta</color>");
            }
            if (change12 == 6)
            {
                WristMenu.ButtonColorDisable = Color.cyan;
                NotifiLib.SendNotification("<color=white>[</color><color=blue>THEME CHANGER</color><color=white>] Disable Button Color: Cyan</color>");
            }
            if (change12 == 7)
            {
                WristMenu.ButtonColorDisable = Color.black;
                NotifiLib.SendNotification("<color=white>[</color><color=blue>THEME CHANGER</color><color=white>] Disable Button Color: Black</color>");
            }
            if (change12 == 8)
            {
                WristMenu.ButtonColorDisable = Color.blue;
                NotifiLib.SendNotification("<color=white>[</color><color=blue>THEME CHANGER</color><color=white>] Disable Button Color: Blue</color>");
            }
            if (change12 == 9)
            {
                WristMenu.ButtonColorDisable = Color.grey;
                NotifiLib.SendNotification("<color=white>[</color><color=blue>THEME CHANGER</color><color=white>] Disable Button Color: Grey</color>");
            }
            if (change12 == 10)
            {
                NotifiLib.SendNotification("<color=white>[</color><color=blue>THEME CHANGER</color><color=white>] Disable Button Color: Clear</color>");
            }
        }
        public static void ThemeChangerV4()
        {
            change13++;
            if (change13 > 10)
            {
                change13 = 1;
            }
            if (change13 == 1)
            {
                WristMenu.ButtonColorEnabled = Color.magenta;
                NotifiLib.SendNotification("<color=white>[</color><color=blue>THEME CHANGER</color><color=white>] Enable Button Color: Magenta</color>");
            }
            if (change13 == 2)
            {
                WristMenu.ButtonColorEnabled = Color.red;
                NotifiLib.SendNotification("<color=white>[</color><color=blue>THEME CHANGER</color><color=white>] Enable Button Color: Red</color>");
            }
            if (change13 == 3)
            {
                WristMenu.ButtonColorEnabled = Color.white;
                NotifiLib.SendNotification("<color=white>[</color><color=blue>THEME CHANGER</color><color=white>] Enable Button Color: White</color>");
            }
            if (change13 == 4)
            {
                WristMenu.ButtonColorEnabled = Color.green;
                NotifiLib.SendNotification("<color=white>[</color><color=blue>THEME CHANGER</color><color=white>] Enable Button Color: Green</color>");
            }
            if (change13 == 5)
            {
                WristMenu.ButtonColorEnabled = Color.yellow;
                NotifiLib.SendNotification("<color=white>[</color><color=blue>THEME CHANGER</color><color=white>] Enable Button Color: Yellow</color>");
            }
            if (change13 == 6)
            {
                WristMenu.ButtonColorEnabled = Color.cyan;
                NotifiLib.SendNotification("<color=white>[</color><color=blue>THEME CHANGER</color><color=white>] Enable Button Color: Cyan</color>");
            }
            if (change13 == 7)
            {
                WristMenu.ButtonColorEnabled = Color.black;
                NotifiLib.SendNotification("<color=white>[</color><color=blue>THEME CHANGER</color><color=white>] Enable Button Color: Black</color>");
            }
            if (change13 == 8)
            {
                WristMenu.ButtonColorEnabled = Color.blue;
                NotifiLib.SendNotification("<color=white>[</color><color=blue>THEME CHANGER</color><color=white>] Enable Button Color: Blue</color>");
            }
            if (change13 == 9)
            {
                WristMenu.ButtonColorEnabled = Color.grey;
                NotifiLib.SendNotification("<color=white>[</color><color=blue>THEME CHANGER</color><color=white>] Enable Button Color: Grey</color>");
            }
            if (change13 == 10)
            {
                NotifiLib.SendNotification("<color=white>[</color><color=blue>THEME CHANGER</color><color=white>] Enable Button Color: Clear</color>");
            }
        }
        public static void ThemeChangerV5()
        {
            change14++;
            if (change14 > 9)
            {
                change14 = 1;
            }
            if (change14 == 1)
            {
                WristMenu.EnableTextColor = Color.black;
                NotifiLib.SendNotification("<color=white>[</color><color=blue>THEME CHANGER</color><color=white>] Enabled Text Color: Black</color>");
            }
            if (change14 == 2)
            {
                WristMenu.EnableTextColor = Color.red;
                NotifiLib.SendNotification("<color=white>[</color><color=blue>THEME CHANGER</color><color=white>] Enabled Text Color: Red</color>");
            }
            if (change14 == 3)
            {
                WristMenu.EnableTextColor = Color.white;
                NotifiLib.SendNotification("<color=white>[</color><color=blue>THEME CHANGER</color><color=white>] Enabled Text Color: White</color>");
            }
            if (change14 == 4)
            {
                WristMenu.EnableTextColor = Color.green;
                NotifiLib.SendNotification("<color=white>[</color><color=blue>THEME CHANGER</color><color=white>] Enabled Text Color: Green</color>");
            }
            if (change14 == 5)
            {
                WristMenu.EnableTextColor = Color.yellow;
                NotifiLib.SendNotification("<color=white>[</color><color=blue>THEME CHANGER</color><color=white>] Enabled Text Color: Yellow</color>");
            }
            if (change14 == 6)
            {
                WristMenu.EnableTextColor = Color.cyan;
                NotifiLib.SendNotification("<color=white>[</color><color=blue>THEME CHANGER</color><color=white>] Enabled Text Color: Cyan</color>");
            }
            if (change14 == 7)
            {
                WristMenu.EnableTextColor = Color.magenta;
                NotifiLib.SendNotification("<color=white>[</color><color=blue>THEME CHANGER</color><color=white>] Enabled Text Color: Magenta</color>");
            }
            if (change14 == 8)
            {
                WristMenu.EnableTextColor = Color.blue;
                NotifiLib.SendNotification("<color=white>[</color><color=blue>THEME CHANGER</color><color=white>] Enabled Text Color: Blue</color>");
            }
            if (change14 == 9)
            {
                WristMenu.EnableTextColor = Color.grey;
                NotifiLib.SendNotification("<color=white>[</color><color=blue>THEME CHANGER</color><color=white>] Enabled Text Color: Grey</color>");
            }
        }
        public static void ThemeChangerV6()
        {
            change15++;
            if (change15 > 9)
            {
                change15 = 1;
            }
            if (change15 == 1)
            {
                WristMenu.DIsableTextColor = Color.black;
                NotifiLib.SendNotification("<color=white>[</color><color=blue>THEME CHANGER</color><color=white>] Disabled Text Color: Black</color>");
            }
            if (change15 == 2)
            {
                WristMenu.DIsableTextColor = Color.red;
                NotifiLib.SendNotification("<color=white>[</color><color=blue>THEME CHANGER</color><color=white>] Disabled Text Color: Red</color>");
            }
            if (change15 == 3)
            {
                WristMenu.DIsableTextColor = Color.white;
                NotifiLib.SendNotification("<color=white>[</color><color=blue>THEME CHANGER</color><color=white>] Disabled Text Color: White</color>");
            }
            if (change15 == 4)
            {
                WristMenu.DIsableTextColor = Color.green;
                NotifiLib.SendNotification("<color=white>[</color><color=blue>THEME CHANGER</color><color=white>] Disabled Text Color: Green</color>");
            }
            if (change15 == 5)
            {
                WristMenu.DIsableTextColor = Color.yellow;
                NotifiLib.SendNotification("<color=white>[</color><color=blue>THEME CHANGER</color><color=white>] Disabled Text Color: Yellow</color>");
            }
            if (change15 == 6)
            {
                WristMenu.DIsableTextColor = Color.cyan;
                NotifiLib.SendNotification("<color=white>[</color><color=blue>THEME CHANGER</color><color=white>] Disabled Text Color: Cyan</color>");
            }
            if (change15 == 7)
            {
                WristMenu.DIsableTextColor = Color.magenta;
                NotifiLib.SendNotification("<color=white>[</color><color=blue>THEME CHANGER</color><color=white>] Disabled Text Color: Magenta</color>");
            }
            if (change15 == 8)
            {
                WristMenu.DIsableTextColor = Color.blue;
                NotifiLib.SendNotification("<color=white>[</color><color=blue>THEME CHANGER</color><color=white>] Disabled Text Color: Blue</color>");
            }
            if (change15 == 9)
            {
                WristMenu.DIsableTextColor = Color.grey;
                NotifiLib.SendNotification("<color=white>[</color><color=blue>THEME CHANGER</color><color=white>] Disabled Text Color: Grey</color>");
            }
        }
        public static void ThemeChangerV7()
        {
            change16++;
            if (change16 > 6)
            {
                change16 = 1;
            }
            if (change16 == 1)
            {
                ButtonSound = 67;
                NotifiLib.SendNotification("<color=white>[</color><color=blue>THEME CHANGER</color><color=white>] Button Sound: Normal</color>");
            }
            if (change16 == 2)
            {
                ButtonSound = 8;
                NotifiLib.SendNotification("<color=white>[</color><color=blue>THEME CHANGER</color><color=white>] Button Sound: Stump</color>");
            }
            if (change16 == 3)
            {
                ButtonSound = 203;
                NotifiLib.SendNotification("<color=white>[</color><color=blue>THEME CHANGER</color><color=white>] Button Sound: AK47</color>");
            }
            if (change16 == 4)
            {
                ButtonSound = 50;
                NotifiLib.SendNotification("<color=white>[</color><color=blue>THEME CHANGER</color><color=white>] Button Sound: Glass</color>");
            }
            if (change16 == 5)
            {
                ButtonSound = 66;
                NotifiLib.SendNotification("<color=white>[</color><color=blue>THEME CHANGER</color><color=white>] Button Sound: KeyBoard</color>");
            }
            if (change16 == 6)
            {
                ButtonSound = 114;
                NotifiLib.SendNotification("<color=white>[</color><color=blue>THEME CHANGER</color><color=white>] Button Sound: Cayon Bridge</color>"); // this sounds the best tbh
            }
        }
        #endregion
        #region GunLib
        public static void MakeGun(Color color, Vector3 pointersize, float linesize, PrimitiveType pointershape, Transform arm, bool liner, Action shit, Action shit1)
        {
            if (arm == GorillaLocomotion.Player.Instance.rightControllerTransform)
            {
                hand = WristMenu.gripDownR;
                hand1 = WristMenu.triggerDownR;
            }
            else if (arm == GorillaLocomotion.Player.Instance.leftControllerTransform)
            {
                hand = WristMenu.gripDownL;
                hand1 = WristMenu.triggerDownL;
            }
            if (hand)
            {
                Physics.Raycast(arm.position, -arm.up, out raycastHit);
                if (pointer == null)
                {
                    pointer = GameObject.CreatePrimitive(pointershape);
                }
                pointer.transform.localScale = pointersize;
                pointer.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
                pointer.transform.position = raycastHit.point;
                pointer.GetComponent<Renderer>().material.color = color;
                if (liner)
                {
                    GameObject g = new GameObject("Line");
                    Line = g.AddComponent<LineRenderer>();
                    Line.material.shader = Shader.Find("GUI/Text Shader");
                    Line.startWidth = linesize;
                    Line.endWidth = linesize;
                    Line.startColor = color;
                    Line.endColor = color;
                    Line.positionCount = 2;
                    Line.useWorldSpace = true;
                    Line.SetPosition(0, arm.position);
                    Line.SetPosition(1, pointer.transform.position);
                    Destroy(g, Time.deltaTime);
                }
                Destroy(pointer.GetComponent<BoxCollider>());
                Destroy(pointer.GetComponent<Rigidbody>());
                Destroy(pointer.GetComponent<Collider>());
                if (hand1)
                {
                    shit.Invoke();
                }
                else
                {
                    shit1.Invoke();
                }
            }
            else
            {
                if (pointer != null)
                {
                    Destroy(pointer, Time.deltaTime);
                }
            }
        }
        // here are some examples of how to use the gunlib
        // this example is for when u only want to execute code when holding ur trigger
        public static void ExampleOnHowToUseGunLib() // this mod is a bug gun
        {
            MakeGun(CurrentGunColor, new Vector3(0.15f, 0.15f, 0.15f), 0.025f, PrimitiveType.Sphere, GorillaLocomotion.Player.Instance.rightControllerTransform, true, delegate
            {
                GameObject.Find("Floating Bug Holdable").transform.position = pointer.transform.position + new Vector3(0f, 0.25f, 0f);
            }, delegate { });
        }
        // this example is for when u want to execute code when holding ur trigger and when ur not holding trigger
        public static void ExampleOnHowToUseGunLibV2() // this mod is a rig gun
        {
            MakeGun(CurrentGunColor, new Vector3(0.15f, 0.15f, 0.15f), 0.025f, PrimitiveType.Sphere, GorillaLocomotion.Player.Instance.rightControllerTransform, true, delegate
            {
                GorillaTagger.Instance.offlineVRRig.enabled = false;
                GorillaTagger.Instance.offlineVRRig.transform.position = pointer.transform.position + new Vector3(0f, 0.3f, 0f);
            }, delegate { GorillaTagger.Instance.offlineVRRig.enabled = true; }); // this code makes ur rig go back to normal if ur not holding ur trigger
        }
        #endregion
        #region Vars
        // random vars
        public static Vector3 Random(float dis)
        {
            Vector3[] ran = new Vector3[]
            {
                new Vector3(dis, 0f, 0f),
                new Vector3(dis, dis, 0f),
                new Vector3(dis, dis, dis),
                new Vector3(dis, 0f, dis),
                new Vector3(0f, 0f, dis),
                new Vector3(0f, dis, dis),
                new Vector3(0f, dis, 0f),
                new Vector3(dis, 0f, 0f),
                new Vector3(dis, dis, 0f),
                new Vector3(dis, dis, dis),
                new Vector3(dis, 0f, dis),
                new Vector3(0f, 0f, dis),
                new Vector3(0f, dis, dis),
                new Vector3(0f, dis, 0f),
            };
            return ran[UnityEngine.Random.Range(0, ran.Length)];
        }

        internal static object FlatRigs(bool v, object enable)
        {
            throw new NotImplementedException();
        }

        // category vars
        public static bool inSettings = false;
        public static bool inCat1 = false;
        public static bool inCat2 = false;
        public static bool inCat3 = false;
        public static bool inCat4 = false;
        public static bool inCat5 = false;
        public static bool inCat6 = false;
        public static bool inCat7 = false;
        public static bool inCat8 = false;
        public static bool inCat9 = false;
        public static bool inCat10 = false;
        // color vars
        public static Color CurrentGunColor = Color.blue;
        public static Color CurrentESPColor = Color.blue;
        // changers
        public static int change1 = 1;
        public static int change2 = 1;
        public static int change3 = 1;
        public static int change4 = 1;
        public static int change6 = 1;
        public static int change7 = 1;
        public static int change8 = 1;
        public static int change9 = 1;
        public static int change10 = 1;
        public static int change11 = 1;
        public static int change12 = 1;
        public static int change13 = 1;
        public static int change14 = 1;
        public static int change15 = 1;
        public static int change16 = 1;
        // rig vars
        public static bool ghostMonke = false;
        public static bool rightHand = false;
        public static bool lastHit;
        public static bool lastHit2;
        public static GameObject orb;
        public static GameObject orb2;
        // random vars
        public static bool FPSPage;
        public static bool RGBMenu;
        public static bool right;
        public static bool fps;
        public static int ButtonSound = 67;
        public static float balll435342111;
        // gun vars
        public static GameObject pointer = null;
        public static LineRenderer Line;
        public static RaycastHit raycastHit;
        public static bool hand = false;
        public static bool hand1 = false;
        // platform vars
        public static bool invisplat = false;
        public static bool invisMonke = false;
        public static bool stickyplatforms = false;
        private static Vector3 scale = new Vector3(0.0125f, 0.28f, 0.3825f);
        private static bool once_left;
        private static bool once_right;
        private static bool once_left_false;
        private static bool once_right_false;
        private static GameObject[] jump_left_network = new GameObject[9999];
        private static GameObject[] jump_right_network = new GameObject[9999];
        private static GameObject jump_left_local = null;
        private static GameObject jump_right_local = null;
        private static GradientColorKey[] colorKeysPlatformMonke = new GradientColorKey[4];
        public static bool TriggerPlats;
        public static bool RPlat;
        public static bool LPlat;
        private static bool muteplayer;
        private static float rightTrigger;
        private static float kgDebounce;
        private static object bones;
        private static bool enable;
        private static float ymcaRigTime;

        public static float HelicopterSpeed { get; private set; }
        #endregion
    }
}

