using System.Linq;
using System;
using System.Collections.Generic;
using TheOtherRoles.Players;
using static TheOtherRoles.TheOtherRoles;
using UnityEngine;
using TheOtherRoles.Utilities;
using TheOtherRoles.CustomGameModes;

namespace TheOtherRoles
{
    class RoleInfo {
        public Color color;
        public string name;
        public string introDescription;
        public string shortDescription;
        public RoleId roleId;
        public bool isNeutral;
        public bool isModifier;

        RoleInfo(string name, Color color, string introDescription, string shortDescription, RoleId roleId, bool isNeutral = false, bool isModifier = false) {
            this.color = color;
            this.name = name;
            this.introDescription = introDescription;
            this.shortDescription = shortDescription;
            this.roleId = roleId;
            this.isNeutral = isNeutral;
            this.isModifier = isModifier;
        }

        public static RoleInfo jester = new RoleInfo("Bouffon", Jester.color, "Être éliminé(e) par vote", "Être éliminé(e) par vote", RoleId.Jester, true);
        public static RoleInfo mayor = new RoleInfo("Maire", Mayor.color, "Votre vote compte double", "Votre vote compte double", RoleId.Mayor);
        public static RoleInfo portalmaker = new RoleInfo("Fabricant de portail", Portalmaker.color, "Vous pouvez créer des portails", "Vous pouvez créer des portails", RoleId.Portalmaker);
        public static RoleInfo engineer = new RoleInfo("Ingénieur", Engineer.color, "Entretenir les systèmes importants du vaisseau", "Réparer le vaisseau", RoleId.Engineer);
        public static RoleInfo sheriff = new RoleInfo("Shérif", Sheriff.color, "Tirer sur les <color=#FF1919FF>Imposteurs</color>", "Tirer sur les Imposteurs", RoleId.Sheriff);
        public static RoleInfo deputy = new RoleInfo("Adjoint(e)", Sheriff.color, "Menotter les <color=#FF1919FF>Imposteurs</color>", "Menotter les Imposteurs", RoleId.Deputy);
        public static RoleInfo lighter = new RoleInfo("Éclaireur", Lighter.color, "Votre lampe ne s'éteint jamais", "Votre lampe ne s'éteint jamais", RoleId.Lighter);
        public static RoleInfo godfather = new RoleInfo("Parrain", Godfather.color, "Tuer tous les membres de l'équipage", "Tuer tous les membres de l'équipage", RoleId.Godfather);
        public static RoleInfo mafioso = new RoleInfo("Mafieux", Mafioso.color, "Travailler avec la <color=#FF1919FF>Mafia</color> pour tuer les membres de l'équipage", "Tuer tous les membres de l'équipage", RoleId.Mafioso);
        public static RoleInfo janitor = new RoleInfo("Concierge", Janitor.color, "Travailler avec la <color=#FF1919FF>Mafia</color> en cachant les cadavres", "Cacher les cadavres", RoleId.Janitor);
        public static RoleInfo morphling = new RoleInfo("Métamorph", Morphling.color, "Changer d'apparence pour ne pas être repéré(e)", "Changer d'apparence", RoleId.Morphling);
        public static RoleInfo camouflager = new RoleInfo("Camoufleur", Camouflager.color, "Se camoufler et tuer les membres de l'équipage", "Se cacher parmi les autres", RoleId.Camouflager);
        public static RoleInfo vampire = new RoleInfo("Vampire", Vampire.color, "Tuer les membres de l'équipage avec vos morsures", "Mordre vos ennemis", RoleId.Vampire);
        public static RoleInfo eraser = new RoleInfo("Effaceur", Eraser.color, "Tuer les membres de l'équipage et effacer leurs rôles", "Effacer les rôles de vos ennemis", RoleId.Eraser);
        public static RoleInfo trickster = new RoleInfo("Farceur", Trickster.color, "Utiliser vos boîtes à surprises pour surprendre les autres", "Surprendre vos ennemis", RoleId.Trickster);
        public static RoleInfo cleaner = new RoleInfo("Nettoyeur", Cleaner.color, "Tuer tout le monde et ne laisser aucune trace", "Nettoyer les corps morts", RoleId.Cleaner);
        public static RoleInfo warlock = new RoleInfo("Sorcier", Warlock.color, "Maudire les autres joueurs et tuer tout le monde", "Maudire et tuer tout le monde", RoleId.Warlock);
        public static RoleInfo bountyHunter = new RoleInfo("Chasseur de primes", BountyHunter.color, "Chasser votre prime", "Chasser votre prime", RoleId.BountyHunter);
        public static RoleInfo detective = new RoleInfo("Détective", Detective.color, "Trouver les <color=#FF1919FF>Imposteurs</color> en examinant les empreintes de pas", "Examiner les empreintes de pas", RoleId.Detective);
        public static RoleInfo timeMaster = new RoleInfo("Maître du temps", TimeMaster.color, "Sauvez-vous avec votre bouclier temporel", "Utilisez votre bouclier temporel", RoleId.TimeMaster);
        public static RoleInfo medic = new RoleInfo("Médecin", Medic.color, "Protégez quelqu'un avec votre bouclier", "Protégez les autres joueurs", RoleId.Medic);
        public static RoleInfo swapper = new RoleInfo("Échangeur", Swapper.color, "Échanger des votes pour exiler les <color=#FF1919FF>Imposteurs</color>", "Échanger des votes", RoleId.Swapper);
        public static RoleInfo seer = new RoleInfo("Voyante", Seer.color, "Vous verrez les joueurs mourir", "Vous verrez les joueurs mourir", RoleId.Seer);
        public static RoleInfo hacker = new RoleInfo("Hacker", Hacker.color, "Pirater des systèmes pour trouver les <color=#FF1919FF>Imposteurs</color>", "Pirater pour trouver les Imposteurs", RoleId.Hacker);
        public static RoleInfo tracker = new RoleInfo("Pisteur", Tracker.color, "Pister les <color=#FF1919FF>Imposteurs</color>", "Pister les Imposteurs", RoleId.Tracker);
        public static RoleInfo snitch = new RoleInfo("Poucave", Snitch.color, "Terminez vos tâches pour trouver les <color=#FF1919FF>Imposteurs</color>", "Terminez vos tâches", RoleId.Snitch);
        public static RoleInfo jackal = new RoleInfo("Chacal", Jackal.color, "Tuer tous les membres de l'équipage et les <color=#FF1919FF>Imposteurs</color> pour gagner", "Tuer tout le monde", RoleId.Jackal, true);
        public static RoleInfo sidekick = new RoleInfo("Acolyte", Sidekick.color, "Aider votre Chacal à tuer tout le monde", "Aider votre Chacal à tuer tout le monde", RoleId.Sidekick, true);
        public static RoleInfo spy = new RoleInfo("Espion", Spy.color, "Confondre les <color=#FF1919FF>Imposteurs</color>", "Confondre les Imposteurs", RoleId.Spy);
        public static RoleInfo securityGuard = new RoleInfo("Gardien", SecurityGuard.color, "Scellez les conduits et placez des caméras", "Scellez les conduits et placez des caméras", RoleId.SecurityGuard);
        public static RoleInfo arsonist = new RoleInfo("Pyromane", Arsonist.color, "Laissez-les brûler", "Laissez-les brûler", RoleId.Arsonist, true);
        public static RoleInfo goodGuesser = new RoleInfo("Devin Gentil", Guesser.color, "Devinez et tirez", "Devinez et tirez", RoleId.NiceGuesser);
        public static RoleInfo badGuesser = new RoleInfo("Devin Maléfique", Palette.ImpostorRed, "Devinez et tirez", "Devinez et tirez", RoleId.EvilGuesser);
        public static RoleInfo vulture = new RoleInfo("Vautour", Vulture.color, "Mangez les corps pour gagner", "Mangez les corps morts", RoleId.Vulture, true);
        public static RoleInfo medium = new RoleInfo("Médium", Medium.color, "Interrogez les âmes des morts pour obtenir des informations", "Interrogez les âmes", RoleId.Medium);
        public static RoleInfo trapper = new RoleInfo("Piègeur", Trapper.color, "Placez des pièges pour trouver les Imposteurs", "Placez des pièges", RoleId.Trapper);
        public static RoleInfo lawyer = new RoleInfo("Avocat", Lawyer.color, "Défendez votre client", "Défendez votre client", RoleId.Lawyer, true);
        public static RoleInfo prosecutor = new RoleInfo("Procureur", Lawyer.color, "Votez contre votre cible", "Votez contre votre cible", RoleId.Prosecutor, true);
        public static RoleInfo pursuer = new RoleInfo("Fugitif", Pursuer.color, "Neutralisez les Imposteurs", "Neutralisez les Imposteurs", RoleId.Pursuer);
        public static RoleInfo impostor = new RoleInfo("Imposteur", Palette.ImpostorRed, Helpers.cs(Palette.ImpostorRed, "Sabotez et tuez tout le monde"), "Sabotez et tuez tout le monde", RoleId.Impostor);
        public static RoleInfo crewmate = new RoleInfo("Crewmate", Color.white, "Trouvez les Imposteurs", "Trouvez les Imposteurs", RoleId.Crewmate);
        public static RoleInfo witch = new RoleInfo("Sorcière", Witch.color, "Lancez un sort sur vos ennemis", "Lancez un sort sur vos ennemis", RoleId.Witch);
        public static RoleInfo ninja = new RoleInfo("Ninja", Ninja.color, "Surprenez et assassinez vos ennemis", "Surprenez et assassinez vos ennemis", RoleId.Ninja);
        public static RoleInfo thief = new RoleInfo("Voleur", Thief.color, "Volez le rôle d'un tueur en le tuant", "Volez le rôle d'un tueur", RoleId.Thief, true);
        public static RoleInfo bomber = new RoleInfo("Bombardier", Bomber.color, "Faites exploser tous les membres de l'équipage", "Faites exploser tous les membres de l'équipage", RoleId.Bomber);
        public static RoleInfo hunter = new RoleInfo("Chasseur", Palette.ImpostorRed, Helpers.cs(Palette.ImpostorRed, "Cherche et tue tout le monde"), "Cherche et tue tout le monde", RoleId.Impostor);
        public static RoleInfo hunted = new RoleInfo("Chassé", Color.white, "Se cacher", "Se cacher", RoleId.Crewmate);

        // Modifier
        public static RoleInfo bloody = new RoleInfo("Sanguinaire", Color.yellow, "Votre meurtrier laisse une trace de sang", "Votre meurtrier laisse une trace de sang", RoleId.Bloody, false, true);
        public static RoleInfo antiTeleport = new RoleInfo("Anti-Téléportation", Color.yellow, "Vous ne serez pas téléporté", "Vous ne serez pas téléporté", RoleId.AntiTeleport, false, true);
        public static RoleInfo tiebreaker = new RoleInfo("Égaliseur", Color.yellow, "Votre vote brise l'égalité", "Brise l'égalité", RoleId.Tiebreaker, false, true);
        public static RoleInfo bait = new RoleInfo("Appât", Color.yellow, "Attirez vos ennemis", "Attirez vos ennemis", RoleId.Bait, false, true);
        public static RoleInfo sunglasses = new RoleInfo("Lunettes de soleil", Color.yellow, "Vous avez des lunettes de soleil", "Votre vision est réduite", RoleId.Sunglasses, false, true);
        public static RoleInfo lover = new RoleInfo("Amoureux", Lovers.color, $"Vous êtes amoureux", $"Vous êtes amoureux", RoleId.Lover, false, true);
        public static RoleInfo mini = new RoleInfo("Enfant", Color.yellow, "Personne ne vous fera de mal jusqu'à ce que vous grandissiez", "Personne ne vous fera de mal", RoleId.Mini, false, true);
        public static RoleInfo vip = new RoleInfo("VIP", Color.yellow, "Vous êtes le VIP", "Tout le monde est informé de votre mort", RoleId.Vip, false, true);
        public static RoleInfo invert = new RoleInfo("Inversé", Color.yellow, "Votre mouvement est inversé", "Votre mouvement est inversé", RoleId.Invert, false, true);
        public static RoleInfo chameleon = new RoleInfo("Caméléon", Color.yellow, "Vous êtes difficile à repérer lorsque vous ne bougez pas", "Vous êtes difficile à repérer lorsque vous ne bougez pas", RoleId.Chameleon, false, true);
        public static RoleInfo shifter = new RoleInfo("Changeur de rôle", Color.yellow, "Changez de rôle", "Changez de rôle", RoleId.Shifter, false, true);


        public static List<RoleInfo> allRoleInfos = new List<RoleInfo>() {
            impostor,
            godfather,
            mafioso,
            janitor,
            morphling,
            camouflager,
            vampire,
            eraser,
            trickster,
            cleaner,
            warlock,
            bountyHunter,
            witch,
            ninja,
            bomber,
            goodGuesser,
            badGuesser,
            lover,
            jester,
            arsonist,
            jackal,
            sidekick,
            vulture,
            pursuer,
            lawyer,
            thief,
            prosecutor,
            crewmate,
            mayor,
            portalmaker,
            engineer,
            sheriff,
            deputy,
            lighter,
            detective,
            timeMaster,
            medic,
            swapper,
            seer,
            hacker,
            tracker,
            snitch,
            spy,
            securityGuard,
            bait,
            medium,
            trapper,
            bloody,
            antiTeleport,
            tiebreaker,
            sunglasses,
            mini,
            vip,
            invert,
            chameleon,
            shifter
        };

        public static List<RoleInfo> getRoleInfoForPlayer(PlayerControl p, bool showModifier = true) {
            List<RoleInfo> infos = new List<RoleInfo>();
            if (p == null) return infos;

            // Modifier
            if (showModifier) {
                // after dead modifier
                if (!CustomOptionHolder.modifiersAreHidden.getBool() || PlayerControl.LocalPlayer.Data.IsDead || AmongUsClient.Instance.GameState == InnerNet.InnerNetClient.GameStates.Ended)
                {
                    if (Bait.bait.Any(x => x.PlayerId == p.PlayerId)) infos.Add(bait);
                    if (Bloody.bloody.Any(x => x.PlayerId == p.PlayerId)) infos.Add(bloody);
                    if (Vip.vip.Any(x => x.PlayerId == p.PlayerId)) infos.Add(vip);
                }
                if (p == Lovers.lover1 || p == Lovers.lover2) infos.Add(lover);
                if (p == Tiebreaker.tiebreaker) infos.Add(tiebreaker);
                if (AntiTeleport.antiTeleport.Any(x => x.PlayerId == p.PlayerId)) infos.Add(antiTeleport);
                if (Sunglasses.sunglasses.Any(x => x.PlayerId == p.PlayerId)) infos.Add(sunglasses);
                if (p == Mini.mini) infos.Add(mini);
                if (Invert.invert.Any(x => x.PlayerId == p.PlayerId)) infos.Add(invert);
                if (Chameleon.chameleon.Any(x => x.PlayerId == p.PlayerId)) infos.Add(chameleon);
                if (p == Shifter.shifter) infos.Add(shifter);
            }

            int count = infos.Count;  // Save count after modifiers are added so that the role count can be checked

            // Special roles
            if (p == Jester.jester) infos.Add(jester);
            if (p == Mayor.mayor) infos.Add(mayor);
            if (p == Portalmaker.portalmaker) infos.Add(portalmaker);
            if (p == Engineer.engineer) infos.Add(engineer);
            if (p == Sheriff.sheriff || p == Sheriff.formerSheriff) infos.Add(sheriff);
            if (p == Deputy.deputy) infos.Add(deputy);
            if (p == Lighter.lighter) infos.Add(lighter);
            if (p == Godfather.godfather) infos.Add(godfather);
            if (p == Mafioso.mafioso) infos.Add(mafioso);
            if (p == Janitor.janitor) infos.Add(janitor);
            if (p == Morphling.morphling) infos.Add(morphling);
            if (p == Camouflager.camouflager) infos.Add(camouflager);
            if (p == Vampire.vampire) infos.Add(vampire);
            if (p == Eraser.eraser) infos.Add(eraser);
            if (p == Trickster.trickster) infos.Add(trickster);
            if (p == Cleaner.cleaner) infos.Add(cleaner);
            if (p == Warlock.warlock) infos.Add(warlock);
            if (p == Witch.witch) infos.Add(witch);
            if (p == Ninja.ninja) infos.Add(ninja);
            if (p == Bomber.bomber) infos.Add(bomber);
            if (p == Detective.detective) infos.Add(detective);
            if (p == TimeMaster.timeMaster) infos.Add(timeMaster);
            if (p == Medic.medic) infos.Add(medic);
            if (p == Swapper.swapper) infos.Add(swapper);
            if (p == Seer.seer) infos.Add(seer);
            if (p == Hacker.hacker) infos.Add(hacker);
            if (p == Tracker.tracker) infos.Add(tracker);
            if (p == Snitch.snitch) infos.Add(snitch);
            if (p == Jackal.jackal || (Jackal.formerJackals != null && Jackal.formerJackals.Any(x => x.PlayerId == p.PlayerId))) infos.Add(jackal);
            if (p == Sidekick.sidekick) infos.Add(sidekick);
            if (p == Spy.spy) infos.Add(spy);
            if (p == SecurityGuard.securityGuard) infos.Add(securityGuard);
            if (p == Arsonist.arsonist) infos.Add(arsonist);
            if (p == Guesser.niceGuesser) infos.Add(goodGuesser);
            if (p == Guesser.evilGuesser) infos.Add(badGuesser);
            if (p == BountyHunter.bountyHunter) infos.Add(bountyHunter);
            if (p == Vulture.vulture) infos.Add(vulture);
            if (p == Medium.medium) infos.Add(medium);
            if (p == Lawyer.lawyer && !Lawyer.isProsecutor) infos.Add(lawyer);
            if (p == Lawyer.lawyer && Lawyer.isProsecutor) infos.Add(prosecutor);
            if (p == Trapper.trapper) infos.Add(trapper);
            if (p == Pursuer.pursuer) infos.Add(pursuer);
            if (p == Thief.thief) infos.Add(thief);

            // Default roles (just impostor, just crewmate, or hunter / hunted for hide n seek
            if (infos.Count == count) {
                if (p.Data.Role.IsImpostor)
                    infos.Add(TORMapOptions.gameMode == CustomGamemodes.HideNSeek ? RoleInfo.hunter : RoleInfo.impostor);
                else
                    infos.Add(TORMapOptions.gameMode == CustomGamemodes.HideNSeek ? RoleInfo.hunted : RoleInfo.crewmate);
            }

            return infos;
        }

        public static String GetRolesString(PlayerControl p, bool useColors, bool showModifier = true, bool suppressGhostInfo = false) {
            string roleName;
            roleName = String.Join(" ", getRoleInfoForPlayer(p, showModifier).Select(x => useColors ? Helpers.cs(x.color, x.name) : x.name).ToArray());
            if (Lawyer.target != null && p.PlayerId == Lawyer.target.PlayerId && CachedPlayer.LocalPlayer.PlayerControl != Lawyer.target) 
                roleName += (useColors ? Helpers.cs(Pursuer.color, " §") : " §");
            if (HandleGuesser.isGuesserGm && HandleGuesser.isGuesser(p.PlayerId)) roleName += " (Guesser)";

            if (!suppressGhostInfo && p != null) {
                if (p == Shifter.shifter && (CachedPlayer.LocalPlayer.PlayerControl == Shifter.shifter || Helpers.shouldShowGhostInfo()) && Shifter.futureShift != null)
                    roleName += Helpers.cs(Color.yellow, " ← " + Shifter.futureShift.Data.PlayerName);
                if (p == Vulture.vulture && (CachedPlayer.LocalPlayer.PlayerControl == Vulture.vulture || Helpers.shouldShowGhostInfo()))
                    roleName = roleName + Helpers.cs(Vulture.color, $" ({Vulture.vultureNumberToWin - Vulture.eatenBodies} left)");
                if (Helpers.shouldShowGhostInfo()) {
                    if (Eraser.futureErased.Contains(p))
                        roleName = Helpers.cs(Color.gray, "(erased) ") + roleName;
                    if (Vampire.vampire != null && !Vampire.vampire.Data.IsDead && Vampire.bitten == p && !p.Data.IsDead)
                        roleName = Helpers.cs(Vampire.color, $"(bitten {(int)HudManagerStartPatch.vampireKillButton.Timer + 1}) ") + roleName;
                    if (Deputy.handcuffedPlayers.Contains(p.PlayerId))
                        roleName = Helpers.cs(Color.gray, "(cuffed) ") + roleName;
                    if (Deputy.handcuffedKnows.ContainsKey(p.PlayerId))  // Active cuff
                        roleName = Helpers.cs(Deputy.color, "(cuffed) ") + roleName;
                    if (p == Warlock.curseVictim)
                        roleName = Helpers.cs(Warlock.color, "(cursed) ") + roleName;
                    if (p == Ninja.ninjaMarked)
                        roleName = Helpers.cs(Ninja.color, "(marked) ") + roleName;
                    if (Pursuer.blankedList.Contains(p) && !p.Data.IsDead)
                        roleName = Helpers.cs(Pursuer.color, "(blanked) ") + roleName;
                    if (Witch.futureSpelled.Contains(p) && !MeetingHud.Instance) // This is already displayed in meetings!
                        roleName = Helpers.cs(Witch.color, "☆ ") + roleName;
                    if (BountyHunter.bounty == p)
                        roleName = Helpers.cs(BountyHunter.color, "(bounty) ") + roleName;
                    if (Arsonist.dousedPlayers.Contains(p))
                        roleName = Helpers.cs(Arsonist.color, "♨ ") + roleName;
                    if (p == Arsonist.arsonist)
                        roleName = roleName + Helpers.cs(Arsonist.color, $" ({CachedPlayer.AllPlayers.Count(x => { return x.PlayerControl != Arsonist.arsonist && !x.Data.IsDead && !x.Data.Disconnected && !Arsonist.dousedPlayers.Any(y => y.PlayerId == x.PlayerId); })} left)");
                    if (p == Jackal.fakeSidekick)
                        roleName = Helpers.cs(Sidekick.color, $" (fake SK)") + roleName;
                }
            }
            return roleName;
        }
    }
}
