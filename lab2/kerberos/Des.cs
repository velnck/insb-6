using System.Collections;

namespace kerberos
{
	internal class Des
	{
		private static byte[] InitialPermutationTable = new byte[]
		{
			58, 50, 42, 34, 26, 18, 10, 2,
			60, 52, 44, 36, 28, 20, 12, 4,
			62, 54, 46, 38, 30, 22, 14, 6,
			64, 56, 48, 40, 32, 24, 16, 8,
			57, 49, 41, 33, 25, 17, 9, 1,
			59, 51, 43, 35, 27, 19, 11, 3,
			61, 53, 45, 37, 29, 21, 13, 5,
			63, 55, 47, 39, 31, 23, 15, 7
		};
		private static byte[] ExpansionTable = new byte[]
		{
			32, 1, 2, 3, 4, 5, 4, 5,
			6, 7, 8, 9, 8, 9, 10, 11,
			12, 13, 12, 13, 14, 15, 16, 17,
			16, 17, 18, 19, 20, 21, 20, 21,
			22, 23, 24, 25, 24, 25, 26, 27,
			28, 29, 28, 29, 30, 31, 32, 1
		};
		private static byte[,,] SBoxes = new byte[,,]
		{
			{
				{ 14, 4, 13, 1, 2, 15, 11, 8, 3, 10, 6, 12, 5, 9, 0, 7 },
				{ 0, 15, 7, 4, 14, 2, 13, 1, 10, 6, 12, 11, 9, 5, 3, 8 },
				{ 4, 1, 14, 8, 13, 6, 2, 11, 15, 12, 9, 7, 3, 10, 5, 0 },
				{ 15, 12, 8, 2, 4, 9, 1, 7, 5, 11, 3, 14, 10, 0, 6, 13 }
			},
			{
				{ 15, 1, 8, 14, 6, 11, 3, 4, 9, 7, 2, 13, 12, 0, 5, 10 },
				{ 3, 13, 4, 7, 15, 2, 8, 14, 12, 0, 1, 10, 6, 9, 11, 5 },
				{ 0, 14, 7, 11, 10, 4, 13, 1, 5, 8, 12, 6, 9, 3, 2, 15 },
				{ 13, 8, 10, 1, 3, 15, 4, 2, 11, 6, 7, 12, 0, 5, 14, 9 }
			},
			{
				{ 10, 0, 9, 14, 6, 3, 15, 5, 1, 13, 12, 7, 11, 4, 2, 8 },
				{ 13, 7, 0, 9, 3, 4, 6, 10, 2, 8, 5, 14, 12, 11, 15, 1 },
				{ 13, 6, 4, 9, 8, 15, 3, 0, 11, 1, 2, 12, 5, 10, 14, 7 },
				{ 1, 10, 13, 0, 6, 9, 8, 7, 4, 15, 14, 3, 11, 5, 2, 12 }
			},
			{
				{ 7, 13, 14, 3, 0, 6, 9, 10, 1, 2, 8, 5, 11, 12, 4, 15 },
				{ 13, 8, 11, 5, 6, 15, 0, 3, 4, 7, 2, 12, 1, 10, 14, 9 },
				{ 10, 6, 9, 0, 12, 11, 7, 13, 15, 1, 3, 14, 5, 2, 8, 4 },
				{ 3, 15, 0, 6, 10, 1, 13, 8, 9, 4, 5, 11, 12, 7, 2, 14 }
			},
			{
				{ 2, 12, 4, 1, 7, 10, 11, 6, 8, 5, 3, 15, 13, 0, 14, 9 },
				{ 14, 11, 2, 12, 4, 7, 13, 1, 5, 0, 15, 10, 3, 9, 8, 6 },
				{ 4, 2, 1, 11, 10, 13, 7, 8, 15, 9, 12, 5, 6, 3, 0, 14 },
				{ 11, 8, 12, 7, 1, 14, 2, 13, 6, 15, 0, 9, 10, 4, 5, 3 }
			},
			{
				{ 12, 1, 10, 15, 9, 2, 6, 8, 0, 13, 3, 4, 14, 7, 5, 11 },
				{ 10, 15, 4, 2, 7, 12, 9, 5, 6, 1, 13, 14, 0, 11, 3, 8 },
				{ 9, 14, 15, 5, 2, 8, 12, 3, 7, 0, 4, 10, 1, 13, 11, 6 },
				{ 4, 3, 2, 12, 9, 5, 15, 10, 11, 14, 1, 7, 6, 0, 8, 13 }
			},
		   	{
				{ 4, 11, 2, 14, 15, 0, 8, 13, 3, 12, 9, 7, 5, 10, 6, 1 },
				{ 13, 0, 11, 7, 4, 9, 1, 10, 14, 3, 5, 12, 2, 15, 8, 6 },
				{ 1, 4, 11, 13, 12, 3, 7, 14, 10, 15, 6, 8, 0, 5, 9, 2 },
				{ 6, 11, 13, 8, 1, 4, 10, 7, 9, 5, 0, 15, 14, 2, 3, 12 }
			},
			{
				{ 13, 2, 8, 4, 6, 15, 11, 1, 10, 9, 3, 14, 5, 0, 12, 7 },
				{ 1, 15, 13, 8, 10, 3, 7, 4, 12, 5, 6, 11, 0, 14, 9, 2 },
				{ 7, 11, 4, 1, 9, 12, 14, 2, 0, 6, 10, 13, 15, 3, 5, 8 },
				{ 2, 1, 14, 7, 4, 10, 8, 13, 15, 12, 9, 0, 3, 5, 6, 11 }
			}
		};
		private static byte[] PTable = new byte[]
		{
			16, 7, 20, 21, 29, 12, 28, 17,
			1, 15, 23, 26, 5, 18, 31, 10,
			2, 8, 24, 14, 32, 27, 3, 9,
			19, 13, 30, 6, 22, 11, 4, 25
		};
		private static byte[] PermutedChoiceTable = new byte[]
		{
			57, 49, 41, 33, 25, 17, 9, 1, 
			58, 50, 42, 34, 26, 18, 10, 2,
			59, 51, 43, 35, 27,	19, 11, 3, 
			60, 52, 44, 36,	
			63, 55, 47, 39, 31, 23, 15,	7, 
			62, 54, 46, 38, 30, 22,	14, 6, 
			61, 53, 45, 37, 29,	21, 13, 5, 
			28, 20, 12, 4
		};
		private static byte[] KeyShiftTable = new byte[]
		{
			1, 1, 2, 2, 2, 2, 2, 2, 1, 2, 2, 2, 2, 2, 2, 1
		};
		private static byte[] KeyCompressionTable = new byte[]
		{
			14, 17, 11, 24, 1, 5, 3, 28, 15, 6, 21, 10,
			23, 19, 12, 4, 26, 8, 16, 7, 27, 20, 13, 2,
			41, 52, 31, 37, 47, 55, 30, 40, 51, 45, 33, 48,
			44, 49, 39, 56, 34, 53, 46, 42, 50, 36, 29, 32
		};
		private static byte[] FinalPermutationTable = new byte[]
		{
			40, 8, 48, 16, 56, 24, 64, 32,
			39, 7, 47, 15, 55, 23, 63, 31,
			38, 6, 46, 14, 54, 22, 62, 30,
			37, 5, 45, 13, 53, 21, 61, 29,
			36, 4, 44, 12, 52, 20, 60, 28,
			35, 3, 43, 11, 51, 19, 59, 27,
			34, 2, 42, 10, 50, 18, 58, 26,
			33, 1, 41, 9, 49, 17, 57, 25
		};

		public static byte[] Encrypt(byte[] message, byte[] key)
        {
			List<BitArray> blocks = GetBlocks(message);
			List<BitArray> encryptedBlocks = new List<BitArray>();
			BitArray keyBitArray = new BitArray(key);
			foreach (BitArray block in blocks)
			{
				BitArray encryptedBlock = EncryptSingleBlock(block, keyBitArray);
				encryptedBlocks.Add(encryptedBlock);
			}
			byte[] encryptedMessage = new byte[encryptedBlocks.Count * 8];
			for (int i = 0; i < encryptedBlocks.Count; i++)
			{
				encryptedBlocks[i].CopyTo(encryptedMessage, i * 8);
			}
            return encryptedMessage;
        }

		private static List<BitArray> GetBlocks(byte[] message)
		{
			while (message.Count() % 8 != 0)
			{
				message = message.Concat(new byte[] { 0 }).ToArray();
			}
			BitArray messageBits = new BitArray(message);
			List<BitArray> blocks = new List<BitArray>();
			for (int i = 0; i < messageBits.Count; i += 64)
			{
				BitArray block = new BitArray(64);
				for (int j = 0; j < 64; j++)
				{
					block[j] = messageBits[i + j];
				}
				blocks.Add(block);
			}
			return blocks;
		}

		private static BitArray EncryptSingleBlock(BitArray block, BitArray key)
		{
			BitArray permutedBlock = new BitArray(64);
			for (int i = 0; i < block.Count; i++)
			{
				permutedBlock[InitialPermutationTable[i] - 1] = block[i]; 
			}

			BitArray prevRight;
			BitArray left = new BitArray(32);
			BitArray right = new BitArray(32);
			BitArray rightExpanded = new BitArray(48);

			for (int i = 0; i < 32; i++)
			{
				left[i] = block[i];
				right[i] = block[i + 32];
			}

			BitArray permutedKey = new BitArray(56);
			for (int i = 0; i < permutedKey.Count; i++)
			{
				permutedKey[i] = key[PermutedChoiceTable[i] - 1];
			}
			BitArray keyLeft = new BitArray(28);
			BitArray keyRight = new BitArray(28);
			for (int i = 0; i < 28; i++)
			{
				keyLeft[i] = permutedKey[i];
				keyRight[i] = permutedKey[i + 28];
			}

			for (int round = 0; round < 16; round++)
			{
				BitArray roundKey = GetRoundKey(round, keyLeft, keyRight);

				for (int i = 0; i < rightExpanded.Count; i++)
				{
					rightExpanded[i] = right[ExpansionTable[i] - 1];
				}
				prevRight = new BitArray(right);

				rightExpanded.Xor(roundKey);
				right = SBoxesTransformation(rightExpanded);
				BitArray permutedRight = new BitArray(32);
				for (int i = 0; i < right.Count; i++)
				{
					permutedRight[PTable[i] - 1] = right[i];
				}
				permutedRight.Xor(left);
				right = new BitArray(permutedRight);
				left = prevRight;
			}
			bool[] encryptedBlock = new bool[64];
			left.CopyTo(encryptedBlock, 0);
			right.CopyTo(encryptedBlock, 32);

			BitArray permutedEncryptedBlock = new BitArray(encryptedBlock.Length);
			for (int i = 0; i < permutedEncryptedBlock.Length; i++)
			{
				permutedEncryptedBlock[i] = encryptedBlock[FinalPermutationTable[i] - 1];
			}
			return new BitArray(encryptedBlock);
		}

		private static BitArray SBoxesTransformation(BitArray bitArray)
		{
			BitArray result = new BitArray(32);
			for (int i = 0; i < bitArray.Count / 6; i++)
			{
				int row = 2 * Convert.ToInt32(bitArray[i * 6]) + Convert.ToInt32(bitArray[i * 6 + 5]);
				int col = 8 * Convert.ToInt32(bitArray[i * 6 + 1]) + 4 * Convert.ToInt32(bitArray[i * 6 + 2])
					+ 2 * Convert.ToInt32(bitArray[i * 6 + 3]) + Convert.ToInt32(bitArray[i * 6 + 4]);
				byte sBoxValue = SBoxes[i, row, col];
				for (int j = 0; j < 4; j++)
				{
					result[i * 4 + j] = (sBoxValue & (2 ^ (3 - j))) == 1;
				}
			}
			return result;
		}

		private static BitArray GetRoundKey(int roundNumber, 
			BitArray prevLeftKey, BitArray prevRightKey)
		{
			for (int shift = 0; shift < KeyShiftTable[roundNumber]; shift++)
			{
				bool temp = prevLeftKey[0];
				prevLeftKey.LeftShift(1);
				prevLeftKey[27] = temp;
				temp = prevRightKey[0];
				prevRightKey.LeftShift(1);
				prevRightKey[27] = temp;
			}
			BitArray key = new BitArray(48);
			for (int i = 0; i < key.Count; i++)
			{
				if (KeyCompressionTable[i] <= 28)
				{
					key[i] = prevLeftKey[KeyCompressionTable[i] - 1];
				}
				else
				{
					key[i] = prevRightKey[KeyCompressionTable[i] - 1 - 28];
				}
			}
			return key;
		}

		public static byte[] Decrypt(byte[] message, byte[] key)
		{
			return null;
		}

	}
}
