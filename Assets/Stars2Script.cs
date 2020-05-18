﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;
using KModkit;

public class Stars2Script : MonoBehaviour
{
	public KMAudio Audio;
    public KMBombInfo Bomb;
    public KMBombModule Module;
	
	public AudioClip[] StarMusical;
	public KMSelectable[] StarFormation;
	public TextMesh Number;
	public KMSelectable[] ComplementaryButtons;
	public MeshRenderer[] Stars;
	public Material[] Colors;
	
	int[] Siphone = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
	int[] SiphoneAnswer = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
	int Costing;
	int Default = 0;
	bool Animating = false;
	
	//Logging
    static int moduleIdCounter = 1;
    int moduleId;
    private bool ModuleSolved;
	
	void Awake()
	{
		moduleId = moduleIdCounter++;
		for (int a = 0; a < 5; a++)
		{
			int Starlight = a;
			StarFormation[Starlight].OnInteract += delegate
			{
				StarPress(Starlight);
				return false;
			};
		}
		
		for (int b = 0; b < 2; b++)
		{
			int Complements = b;
			ComplementaryButtons[Complements].OnInteract += delegate
			{
				Status(Complements);
				return false;
			};
		}
	}
	
	void Start()
	{
		GenerateHopping();
		SelectionSequence();
	}
	
	void GenerateHopping()
	{
		Costing = UnityEngine.Random.Range(0,10);
		Debug.LogFormat("[Stars #{0}] The number shown in the module is: {1}", moduleId, Costing.ToString());
		Number.text = Costing.ToString();
		if (Bomb.IsIndicatorPresent("CAR"))
			{
				Costing = (Costing + Bomb.GetBatteryCount()) % 10;
				Debug.LogFormat("[Stars #{0}] There is a CAR indicator. The value of actually value that must be used is: {1}", moduleId, Costing.ToString());
			}
	}
	
	void SelectionSequence()
	{
		if (Bomb.IsPortPresent(Port.RJ45))
		{
			Debug.LogFormat("[Stars #{0}] Column 1 is the correct column", moduleId);
			if (Costing == 0)
			{
				int[] Prototype = {2, 3, 4, 0, 0, 0, 0, 0, 0, 0};
				for (int x = 0; x < Siphone.Count(); x++)
				{
					Siphone[x] = Prototype[x];
				}
				Debug.LogFormat("[Stars #{0}] The sequence that must be submitted is: 2, 3, 4", moduleId);
			}
			
			else if (Costing == 1)
			{
				int[] Prototype = {3, 2, 1, 0, 0, 0, 0, 0, 0, 0};
				for (int x = 0; x < Siphone.Count(); x++)
				{
					Siphone[x] = Prototype[x];
				}
				Debug.LogFormat("[Stars #{0}] The sequence that must be submitted is: 3, 2, 1", moduleId);
			}
			
			else if (Costing == 2)
			{
				int[] Prototype = {4, 2, 5, 1, 2, 3, 0, 0, 0, 0};
				for (int x = 0; x < Siphone.Count(); x++)
				{
					Siphone[x] = Prototype[x];
				}
				Debug.LogFormat("[Stars #{0}] The sequence that must be submitted is: 4, 2, 5, 1, 2, 3", moduleId);
			}
			
			else if (Costing == 3)
			{
				int[] Prototype = {1, 0, 0, 0, 0, 0, 0, 0, 0, 0};
				for (int x = 0; x < Siphone.Count(); x++)
				{
					Siphone[x] = Prototype[x];
				}
				Debug.LogFormat("[Stars #{0}] The sequence that must be submitted is: 1", moduleId);
			}
			
			else if (Costing == 4)
			{
				int[] Prototype = {2, 5, 0, 0, 0, 0, 0, 0, 0, 0};
				for (int x = 0; x < Siphone.Count(); x++)
				{
					Siphone[x] = Prototype[x];
				}
				Debug.LogFormat("[Stars #{0}] The sequence that must be submitted is: 2, 5", moduleId);
			}
			
			else if (Costing == 5)
			{
				int[] Prototype = {3, 2, 4, 2, 0, 0, 0, 0, 0, 0};
				for (int x = 0; x < Siphone.Count(); x++)
				{
					Siphone[x] = Prototype[x];
				}
				Debug.LogFormat("[Stars #{0}] The sequence that must be submitted is: 3, 2, 4, 2", moduleId);
			}
			
			else if (Costing == 6)
			{
				int[] Prototype = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
				for (int x = 0; x < Siphone.Count(); x++)
				{
					Siphone[x] = Prototype[x];
				}
				Debug.LogFormat("[Stars #{0}] The sequence that must be submitted is: 0", moduleId);
			}
			
			else if (Costing == 7)
			{
				int[] Prototype = {5, 5, 0, 0, 0, 0, 0, 0, 0, 0};
				for (int x = 0; x < Siphone.Count(); x++)
				{
					Siphone[x] = Prototype[x];
				}
				Debug.LogFormat("[Stars #{0}] The sequence that must be submitted is: 5, 5", moduleId);
			}
			
			else if (Costing == 8)
			{
				int[] Prototype = {1, 1, 1, 5, 5, 5, 0, 0, 0, 0};
				for (int x = 0; x < Siphone.Count(); x++)
				{
					Siphone[x] = Prototype[x];
				}
				Debug.LogFormat("[Stars #{0}] The sequence that must be submitted is: 1, 1, 1, 5, 5, 5", moduleId);
			}
			
			else if (Costing == 9)
			{
				int[] Prototype = {1, 4, 2, 5, 3, 0, 0, 0, 0, 0};
				for (int x = 0; x < Siphone.Count(); x++)
				{
					Siphone[x] = Prototype[x];
				}
				Debug.LogFormat("[Stars #{0}] The sequence that must be submitted is: 1, 4, 2, 5, 3", moduleId);
			}
		}
		
		else if (Bomb.GetBatteryCount() > 3)
		{
			Debug.LogFormat("[Stars #{0}] Column 2 is the correct column", moduleId);
			if (Costing == 0)
			{
				int[] Prototype = {1, 4, 4, 3, 0, 0, 0, 0, 0, 0};
				for (int x = 0; x < Siphone.Count(); x++)
				{
					Siphone[x] = Prototype[x];
				}
				Debug.LogFormat("[Stars #{0}] The sequence that must be submitted is: 1, 4, 4, 3", moduleId);
			}
			
			else if (Costing == 1)
			{
				int[] Prototype = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
				for (int x = 0; x < Siphone.Count(); x++)
				{
					Siphone[x] = Prototype[x];
				}
				Debug.LogFormat("[Stars #{0}] The sequence that must be submitted is: 0", moduleId);
			}
			
			else if (Costing == 2)
			{
				int[] Prototype = {5, 4, 3, 2, 1, 0, 0, 0, 0, 0};
				for (int x = 0; x < Siphone.Count(); x++)
				{
					Siphone[x] = Prototype[x];
				}
				Debug.LogFormat("[Stars #{0}] The sequence that must be submitted is: 5, 4, 3, 2, 1", moduleId);
			}
			
			else if (Costing == 3)
			{
				int[] Prototype = {2, 2, 0, 0, 0, 0, 0, 0, 0, 0};
				for (int x = 0; x < Siphone.Count(); x++)
				{
					Siphone[x] = Prototype[x];
				}
				Debug.LogFormat("[Stars #{0}] The sequence that must be submitted is: 2, 2", moduleId);
			}
			
			else if (Costing == 4)
			{
				int[] Prototype = {4, 1, 4, 0, 0, 0, 0, 0, 0, 0};
				for (int x = 0; x < Siphone.Count(); x++)
				{
					Siphone[x] = Prototype[x];
				}
				Debug.LogFormat("[Stars #{0}] The sequence that must be submitted is: 4, 1, 4", moduleId);
			}
			
			else if (Costing == 5)
			{
				int[] Prototype = {4, 4, 3, 1, 2, 0, 0, 0, 0, 0};
				for (int x = 0; x < Siphone.Count(); x++)
				{
					Siphone[x] = Prototype[x];
				}
				Debug.LogFormat("[Stars #{0}] The sequence that must be submitted is: 4, 4, 3, 1, 2", moduleId);
			}
			
			else if (Costing == 6)
			{
				int[] Prototype = {2, 3, 0, 0, 0, 0, 0, 0, 0, 0};
				for (int x = 0; x < Siphone.Count(); x++)
				{
					Siphone[x] = Prototype[x];
				}
				Debug.LogFormat("[Stars #{0}] The sequence that must be submitted is: 2, 3", moduleId);
			}
			
			else if (Costing == 7)
			{
				int[] Prototype = {4, 3, 2, 4, 5, 0, 0, 0, 0, 0};
				for (int x = 0; x < Siphone.Count(); x++)
				{
					Siphone[x] = Prototype[x];
				}
				Debug.LogFormat("[Stars #{0}] The sequence that must be submitted is: 4, 3, 2, 4, 5", moduleId);
			}
			
			else if (Costing == 8)
			{
				int[] Prototype = {5, 3, 5, 4, 0, 0, 0, 0, 0, 0};
				for (int x = 0; x < Siphone.Count(); x++)
				{
					Siphone[x] = Prototype[x];
				}
				Debug.LogFormat("[Stars #{0}] The sequence that must be submitted is: 5, 3, 5, 4", moduleId);
			}
			
			else if (Costing == 9)
			{
				int[] Prototype = {5, 2, 4, 5, 0, 0, 0, 0, 0, 0};
				for (int x = 0; x < Siphone.Count(); x++)
				{
					Siphone[x] = Prototype[x];
				}
				Debug.LogFormat("[Stars #{0}] The sequence that must be submitted is: 5, 2, 4, 5", moduleId);
			}
		}
		
		else if (Bomb.GetSerialNumber().Contains("S") || Bomb.GetSerialNumber().Contains("T") || Bomb.GetSerialNumber().Contains("A") || Bomb.GetSerialNumber().Contains("R"))
		{
			Debug.LogFormat("[Stars #{0}] Column 3 is the correct column", moduleId);
			if (Costing == 0)
			{
				int[] Prototype = {5, 5, 5, 3, 3, 0, 0, 0, 0, 0};
				for (int x = 0; x < Siphone.Count(); x++)
				{
					Siphone[x] = Prototype[x];
				}
				Debug.LogFormat("[Stars #{0}] The sequence that must be submitted is: 5, 5, 5, 3, 3", moduleId);
			}
			
			else if (Costing == 1)
			{
				int[] Prototype = {1, 2, 1, 0, 0, 0, 0, 0, 0, 0};
				for (int x = 0; x < Siphone.Count(); x++)
				{
					Siphone[x] = Prototype[x];
				}
				Debug.LogFormat("[Stars #{0}] The sequence that must be submitted is: 1, 2, 1", moduleId);
			}
			
			else if (Costing == 2)
			{
				int[] Prototype = {4, 2, 3, 0, 0, 0, 0, 0, 0, 0};
				for (int x = 0; x < Siphone.Count(); x++)
				{
					Siphone[x] = Prototype[x];
				}
				Debug.LogFormat("[Stars #{0}] The sequence that must be submitted is: 4, 2, 3", moduleId);
			}
			
			else if (Costing == 3)
			{
				int[] Prototype = {3, 3, 3, 0, 0, 0, 0, 0, 0, 0};
				for (int x = 0; x < Siphone.Count(); x++)
				{
					Siphone[x] = Prototype[x];
				}
				Debug.LogFormat("[Stars #{0}] The sequence that must be submitted is: 3, 3, 3", moduleId);
			}
			
			else if (Costing == 4)
			{
				int[] Prototype = {1, 5, 4, 4, 3, 2, 0, 0, 0, 0};
				for (int x = 0; x < Siphone.Count(); x++)
				{
					Siphone[x] = Prototype[x];
				}
				Debug.LogFormat("[Stars #{0}] The sequence that must be submitted is: 1, 5, 4, 4, 3, 2", moduleId);
			}
			
			else if (Costing == 5)
			{
				int[] Prototype = {5, 5, 2, 5, 0, 0, 0, 0, 0, 0};
				for (int x = 0; x < Siphone.Count(); x++)
				{
					Siphone[x] = Prototype[x];
				}
				Debug.LogFormat("[Stars #{0}] The sequence that must be submitted is: 5, 5, 2, 5", moduleId);
			}
			
			else if (Costing == 6)
			{
				int[] Prototype = {1, 5, 0, 0, 0, 0, 0, 0, 0, 0};
				for (int x = 0; x < Siphone.Count(); x++)
				{
					Siphone[x] = Prototype[x];
				}
				Debug.LogFormat("[Stars #{0}] The sequence that must be submitted is: 1, 5", moduleId);
			}
			
			else if (Costing == 7)
			{
				int[] Prototype = {1, 1, 1, 0, 0, 0, 0, 0, 0, 0};
				for (int x = 0; x < Siphone.Count(); x++)
				{
					Siphone[x] = Prototype[x];
				}
				Debug.LogFormat("[Stars #{0}] The sequence that must be submitted is: 1, 1, 1", moduleId);
			}
			
			else if (Costing == 8)
			{
				int[] Prototype = {2, 2, 5, 0, 0, 0, 0, 0, 0, 0};
				for (int x = 0; x < Siphone.Count(); x++)
				{
					Siphone[x] = Prototype[x];
				}
				Debug.LogFormat("[Stars #{0}] The sequence that must be submitted is: 2, 2, 5", moduleId);
			}
			
			else if (Costing == 9)
			{
				int[] Prototype = {2, 4, 4, 1, 3, 0, 0, 0, 0, 0};
				for (int x = 0; x < Siphone.Count(); x++)
				{
					Siphone[x] = Prototype[x];
				}
				Debug.LogFormat("[Stars #{0}] The sequence that must be submitted is: 2, 4, 4, 1, 3", moduleId);
			}
		}
		
		else if (Bomb.GetOnIndicators().Count() == 0)
		{
			Debug.LogFormat("[Stars #{0}] Column 4 is the correct column", moduleId);
			if (Costing == 0)
			{
				int[] Prototype = {1, 2, 3, 4, 5, 0, 0, 0, 0, 0};
				for (int x = 0; x < Siphone.Count(); x++)
				{
					Siphone[x] = Prototype[x];
				}
				Debug.LogFormat("[Stars #{0}] The sequence that must be submitted is: 1, 2, 3, 4, 5", moduleId);
			}
			
			else if (Costing == 1)
			{
				int[] Prototype = {1, 1, 2, 2, 3, 3, 0, 0, 0, 0};
				for (int x = 0; x < Siphone.Count(); x++)
				{
					Siphone[x] = Prototype[x];
				}
				Debug.LogFormat("[Stars #{0}] The sequence that must be submitted is: 1, 1, 2, 2, 3, 3", moduleId);
			}
			
			else if (Costing == 2)
			{
				int[] Prototype = {5, 3, 1, 0, 0, 0, 0, 0, 0, 0};
				for (int x = 0; x < Siphone.Count(); x++)
				{
					Siphone[x] = Prototype[x];
				}
				Debug.LogFormat("[Stars #{0}] The sequence that must be submitted is: 5, 3, 1", moduleId);
			}
			
			else if (Costing == 3)
			{
				int[] Prototype = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
				for (int x = 0; x < Siphone.Count(); x++)
				{
					Siphone[x] = Prototype[x];
				}
				Debug.LogFormat("[Stars #{0}] The sequence that must be submitted is: 0", moduleId);
			}
			
			else if (Costing == 4)
			{
				int[] Prototype = {3, 4, 2, 0, 0, 0, 0, 0, 0, 0};
				for (int x = 0; x < Siphone.Count(); x++)
				{
					Siphone[x] = Prototype[x];
				}
				Debug.LogFormat("[Stars #{0}] The sequence that must be submitted is: 3, 4, 2", moduleId);
			}
			
			else if (Costing == 5)
			{
				int[] Prototype = {1, 2, 3, 4, 5, 4, 3, 2, 1, 0};
				for (int x = 0; x < Siphone.Count(); x++)
				{
					Siphone[x] = Prototype[x];
				}
				Debug.LogFormat("[Stars #{0}] The sequence that must be submitted is: 1, 2, 3, 4, 5, 4, 3, 2, 1", moduleId);
			}
			
			else if (Costing == 6)
			{
				int[] Prototype = {3, 0, 0, 0, 0, 0, 0, 0, 0, 0};
				for (int x = 0; x < Siphone.Count(); x++)
				{
					Siphone[x] = Prototype[x];
				}
				Debug.LogFormat("[Stars #{0}] The sequence that must be submitted is: 3", moduleId);
			}
			
			else if (Costing == 7)
			{
				int[] Prototype = {5, 4, 3, 0, 0, 0, 0, 0, 0, 0};
				for (int x = 0; x < Siphone.Count(); x++)
				{
					Siphone[x] = Prototype[x];
				}
				Debug.LogFormat("[Stars #{0}] The sequence that must be submitted is: 5, 4, 3", moduleId);
			}
			
			else if (Costing == 8)
			{
				int[] Prototype = {3, 1, 0, 0, 0, 0, 0, 0, 0, 0};
				for (int x = 0; x < Siphone.Count(); x++)
				{
					Siphone[x] = Prototype[x];
				}
				Debug.LogFormat("[Stars #{0}] The sequence that must be submitted is: 3, 1", moduleId);
			}
			
			else if (Costing == 9)
			{
				int[] Prototype = {5, 4, 3, 1, 2, 0, 0, 0, 0, 0};
				for (int x = 0; x < Siphone.Count(); x++)
				{
					Siphone[x] = Prototype[x];
				}
				Debug.LogFormat("[Stars #{0}] The sequence that must be submitted is: 5, 4, 3, 1, 2", moduleId);
			}
		}
		
		else
		{
			Debug.LogFormat("[Stars #{0}] Column 5 is the correct column", moduleId);
			if (Costing == 0)
			{
				int[] Prototype = {2, 5, 0, 0, 0, 0, 0, 0, 0, 0};
				for (int x = 0; x < Siphone.Count(); x++)
				{
					Siphone[x] = Prototype[x];
				}
				Debug.LogFormat("[Stars #{0}] The sequence that must be submitted is: 2, 5", moduleId);
			}
			
			else if (Costing == 1)
			{
				int[] Prototype = {5, 1, 4, 0, 0, 0, 0, 0, 0, 0};
				for (int x = 0; x < Siphone.Count(); x++)
				{
					Siphone[x] = Prototype[x];
				}
				Debug.LogFormat("[Stars #{0}] The sequence that must be submitted is: 5, 1, 4", moduleId);
			}
			
			else if (Costing == 2)
			{
				int[] Prototype = {1, 1, 4, 0, 0, 0, 0, 0, 0, 0};
				for (int x = 0; x < Siphone.Count(); x++)
				{
					Siphone[x] = Prototype[x];
				}
				Debug.LogFormat("[Stars #{0}] The sequence that must be submitted is: 1, 1, 4", moduleId);
			}
			
			else if (Costing == 3)
			{
				int[] Prototype = {1, 3, 5, 0, 0, 0, 0, 0, 0, 0};
				for (int x = 0; x < Siphone.Count(); x++)
				{
					Siphone[x] = Prototype[x];
				}
				Debug.LogFormat("[Stars #{0}] The sequence that must be submitted is: 1, 3, 5", moduleId);
			}
			
			else if (Costing == 4)
			{
				int[] Prototype = {5, 0, 0, 0, 0, 0, 0, 0, 0, 0};
				for (int x = 0; x < Siphone.Count(); x++)
				{
					Siphone[x] = Prototype[x];
				}
				Debug.LogFormat("[Stars #{0}] The sequence that must be submitted is: 5", moduleId);
			}
			
			else if (Costing == 5)
			{
				int[] Prototype = {3, 3, 3, 3, 1, 0, 0, 0, 0, 0};
				for (int x = 0; x < Siphone.Count(); x++)
				{
					Siphone[x] = Prototype[x];
				}
				Debug.LogFormat("[Stars #{0}] The sequence that must be submitted is: 3, 3, 3, 3, 1", moduleId);
			}
			
			else if (Costing == 6)
			{
				int[] Prototype = {3, 4, 1, 2, 1, 2, 4, 0, 0, 0};
				for (int x = 0; x < Siphone.Count(); x++)
				{
					Siphone[x] = Prototype[x];
				}
				Debug.LogFormat("[Stars #{0}] The sequence that must be submitted is: 3, 4, 1, 2, 1, 2, 4", moduleId);
			}
			
			else if (Costing == 7)
			{
				int[] Prototype = {1, 5, 2, 0, 0, 0, 0, 0, 0, 0};
				for (int x = 0; x < Siphone.Count(); x++)
				{
					Siphone[x] = Prototype[x];
				}
				Debug.LogFormat("[Stars #{0}] The sequence that must be submitted is: 1, 5, 2", moduleId);
			}
			
			else if (Costing == 8)
			{
				int[] Prototype = {1, 4, 2, 0, 0, 0, 0, 0, 0, 0};
				for (int x = 0; x < Siphone.Count(); x++)
				{
					Siphone[x] = Prototype[x];
				}
				Debug.LogFormat("[Stars #{0}] The sequence that must be submitted is: 1, 4, 2", moduleId);
			}
			
			else if (Costing == 9)
			{
				int[] Prototype = {5, 2, 0, 0, 0, 0, 0, 0, 0, 0};
				for (int x = 0; x < Siphone.Count(); x++)
				{
					Siphone[x] = Prototype[x];
				}
				Debug.LogFormat("[Stars #{0}] The sequence that must be submitted is: 5, 2", moduleId);
			}
		}
	}
	
	void StarPress(int Starlight)
	{
		StarFormation[Starlight].AddInteractionPunch(0.2f);
		if (Animating == false && ModuleSolved == false)
		{
			Audio.PlaySoundAtTransform(StarMusical[Starlight].name, transform);
			SiphoneAnswer[Default] = Starlight + 1;
			if (Default != 9)
			{
				Default++;
			}
		}
	}
	
	
	void Status(int Complements)
	{
		ComplementaryButtons[Complements].AddInteractionPunch(0.2f);
		if (Animating == false && ModuleSolved == false)
		{
			if (Complements == 0)
			{
				Audio.PlaySoundAtTransform(StarMusical[5].name, transform);
				for (int x = 0; x < 10; x++)
				{
					SiphoneAnswer[x] = 0;
				}
				Default = 0;
				Debug.LogFormat("[Stars #{0}] All inputs has been cleared", moduleId);
			}
			
			else if (Complements == 1)
			{
				StartCoroutine(Starlighting());
				Animating = true;
				int ZeroCount = 0;
				for (int x = 0; x < 10; x++)
				{
					if (SiphoneAnswer[x] == 0)
					{
						ZeroCount++;
					}
				}
				if (ZeroCount == 10)
				{
					Debug.LogFormat("[Stars #{0}] The sequence you submitted is: 0", moduleId);
				}
				else if (ZeroCount == 0)
				{
					string logans = "";
					for (int i = 0; i < 10; i++)
					{
						if (i != 9)
						{
							logans += SiphoneAnswer[i].ToString()+", ";
						}
						else
						{
							logans += "...";
						}
					}
					Debug.LogFormat("[Stars #{0}] The sequence you submitted is: {1}", moduleId, logans);
				}
				else
				{
					string logans = "";
					for (int i = 0; i < 10-ZeroCount; i++)
					{
						if (i != (10-ZeroCount-1))
						{
							logans += SiphoneAnswer[i].ToString()+", ";
						}
						else
						{
							logans += SiphoneAnswer[i].ToString();
						}
					}
					Debug.LogFormat("[Stars #{0}] The sequence you submitted is: {1}", moduleId, logans);
				}
			}
		}
	}
	
	IEnumerator Starlighting()
	{
		bool Mistake = false;
		for (int x = 0; x < 10; x++)
		{
			if (SiphoneAnswer[x] != Siphone[x])
			{
				Mistake = true;
				break;
			}
		}
		Audio.PlaySoundAtTransform(StarMusical[6].name, transform);
		
		Stars[0].material = Colors[2];
		yield return new WaitForSecondsRealtime(0.74f);
		Stars[1].material = Colors[2];
		yield return new WaitForSecondsRealtime(0.74f);
		Stars[2].material = Colors[2];
		yield return new WaitForSecondsRealtime(0.74f);
		Stars[3].material = Colors[2];
		yield return new WaitForSecondsRealtime(0.74f);
		Stars[4].material = Colors[2];
		yield return new WaitForSecondsRealtime(0.94f);
		for (int x = 0; x < Stars.Count(); x++)
		{
			Stars[x].material = Colors[4];
		}
		yield return new WaitForSecondsRealtime(0.81f);
		for (int a = 0; a < Stars.Count(); a++)
		{
			Stars[a].material = Colors[2];
		}
		yield return new WaitForSecondsRealtime(1.9f);
		Stars[0].material = Colors[3];
		yield return new WaitForSecondsRealtime(0.74f);
		Stars[1].material = Colors[3];
		yield return new WaitForSecondsRealtime(0.74f);
		Stars[2].material = Colors[3];
		yield return new WaitForSecondsRealtime(0.74f);
		Stars[3].material = Colors[3];
		yield return new WaitForSecondsRealtime(0.74f);
		Stars[4].material = Colors[3];
		yield return new WaitForSecondsRealtime(0.96f);
		for (int x = 0; x < Stars.Count(); x++)
		{
			Stars[x].material = Colors[4];
		}
		yield return new WaitForSecondsRealtime(0.82f);
		for (int a = 0; a < Stars.Count(); a++)
		{
			Stars[a].material = Colors[3];
		}
		yield return new WaitForSecondsRealtime(1.7f);
		
		if (Mistake == true)
		{
			Debug.LogFormat("[Stars #{0}] The sequence given is incorrect. A strike was given.", moduleId);
			Module.HandleStrike();
			for (int x = 0; x < 10; x++)
			{
				SiphoneAnswer[x] = 0;
			}
			Default = 0;
			for (int x = 0; x < Stars.Count(); x++)
			{
				Stars[x].material = Colors[0];
			}
			yield return new WaitForSecondsRealtime(0.6f);
			for (int x = 0; x < Stars.Count(); x++)
			{
				Stars[x].material = Colors[3];
			}
		}
		
		else
		{
			Debug.LogFormat("[Stars #{0}] The sequence given is correct. Module solved.", moduleId);
			Module.HandlePass();
			Audio.PlaySoundAtTransform(StarMusical[7].name, transform);
			ModuleSolved = true;
			Number.text = "";
			for (int x = 0; x < Stars.Count(); x++)
			{
				Stars[x].material = Colors[1];
				yield return new WaitForSecondsRealtime(0.2f);
			}
		}
		
		Animating = false;
	}
	
	//twitch plays
    #pragma warning disable 414
    private readonly string TwitchHelpMessage = @"To press the buttons that is in a star formation, use the command !{0} press [1-5] (You can perform the command in a chain) | To submit your answer, use the command !{0} submit | To clear all your inputs, use the command !{0} clear";
    #pragma warning restore 414
	string[] Flashlight = {"1", "2", "3", "4", "5"};
	
	IEnumerator ProcessTwitchCommand(string command)
	{
		string[] parameters = command.Split(' ');
		if (Regex.IsMatch(parameters[0], @"^\s*press\s*$", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant))
		{
			yield return null;
			if (parameters.Length != 2)
			{
				yield return "sendtochaterror Invalid parameter length.";
				yield break;
			}
			
			if (Animating == true)
			{
				yield return "sendtochaterror The module is performing an animation. Command ignored";
				yield break;
			}
			
			foreach (char c in parameters[1])
			{
				if (!c.ToString().EqualsAny(Flashlight))
				{
					yield return "sendtochaterror The current character is not between 1-5.";
					yield break;
				}
				StarFormation[Int32.Parse(c.ToString())-1].OnInteract();
				yield return new WaitForSecondsRealtime(0.2f);
			}
		}
			
		if (Regex.IsMatch(command, @"^\s*clear\s*$", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant))
		{
			yield return null;
			if (Animating == true)
			{
				yield return "sendtochaterror The module is performing an animation. Command ignored";
				yield break;
			}
			ComplementaryButtons[0].OnInteract();
		}
		
		if (Regex.IsMatch(command, @"^\s*submit\s*$", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant))
		{
			yield return null;
			if (Animating == true)
			{
				yield return "sendtochaterror The module is performing an animation. Command ignored";
				yield break;
			}
			yield return "solve";
			yield return "strike";
			ComplementaryButtons[1].OnInteract();
		}
	}
}
