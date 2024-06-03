using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Steamworks;
using Steamworks.Data;
using System.Threading.Tasks;

namespace Rycon.Online.SteamTools
{
    public static class SteamAvatarHelper
    {
        public static async Task<Image?> GetAvatar(ulong steamid)
        {
            try
            {
                return await SteamFriends.GetLargeAvatarAsync(steamid);
            }
            catch (System.Exception e)
            {
                Debug.Log(e);
                return null;
            }
        }

        public static Texture2D Covert(this Image image)
        {
            // Create a new Texture2D
            var avatar = new Texture2D((int)image.Width, (int)image.Height, TextureFormat.ARGB32, false);

            // Set filter type, or else its really blury
            avatar.filterMode = FilterMode.Trilinear;

            // Flip image
            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    var p = image.GetPixel(x, y);
                    avatar.SetPixel(x, (int)image.Height - y, new UnityEngine.Color(p.r / 255.0f, p.g / 255.0f, p.b / 255.0f, p.a / 255.0f));
                }
            }

            avatar.Apply();
            return avatar;
        }
    }
}