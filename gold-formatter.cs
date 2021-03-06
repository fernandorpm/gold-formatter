        string currentGold = Mathf.Round(this.totalGold - this.spentGold).ToString();
        string clippedGold = currentGold;

        goldChunk.Clear();


        if (currentGold.Length >= 4)
        {
            for (int i = clippedGold.Length - 1; i >= 0; i -= 3)
            {
                if (i - 3 >= -1)
                {
                    // 3 or more numbers
                    goldChunk.Add(clippedGold.Substring(i - 2));
                    clippedGold = clippedGold.Remove(i - 2);
                }
                else if (i - 3 == -2)
                {
                    // 2 numbers
                    goldChunk.Add(clippedGold.Substring(i - 1));
                    clippedGold = clippedGold.Remove(i - 1);
                }
                else if (i - 3 <= -3)
                {
                    // 1 or less numbers
                    goldChunk.Add(clippedGold.Substring(i));
                    clippedGold = clippedGold.Remove(i);
                }
            }

            clippedGold = "";
            goldChunk.Reverse();

            clippedGold = string.Join<string>(".", goldChunk);

            int clipIndex = clippedGold.IndexOf(".") + 3;

            clippedGold = clippedGold.Substring(0, clipIndex);

            if (currentGold.Length > 6)
            {
                double thousandDivider = 3;
                int goldLetter = (int)Math.Ceiling(currentGold.Length / thousandDivider);
                clippedGold += " A" + Convert.ToChar(62 + goldLetter);
            }
            else
            {
                clippedGold += " K";
            }

        }

        Debug.Log(clippedGold);
