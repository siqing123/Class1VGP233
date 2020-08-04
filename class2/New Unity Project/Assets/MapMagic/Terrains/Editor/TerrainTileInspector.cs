﻿
using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

using Den.Tools;
using Den.Tools.GUI;

using MapMagic.Nodes;
using MapMagic.Terrains;


namespace MapMagic.Core.GUI 
{
	[CustomEditor(typeof(TerrainTile))]
	public class TerrainTileInspector : Editor
	{
		UI ui = new UI();


		/*[RuntimeInitializeOnLoadMethod, UnityEditor.InitializeOnLoadMethod] 
		static void Subscribe ()
		{
			MapMagicObject.OnLodSwitched += (TerrainTile t,bool m, bool d) => SceneView.RepaintAll();
		}*/


		//when selected
		/*public void OnSceneGUI ()
		{	

		}*/


		public override void  OnInspectorGUI ()
		{
			ui.Draw(DrawGUI);
		}

		static readonly string[] currentLodNames = new string[] { "None", "Draft", "Main" };

		public void DrawGUI ()
		{
			TerrainTile tile = (TerrainTile)target;

			using (Cell.LinePx(0))
			{
				Cell.current.disabled = true;

				using (Cell.LineStd) Draw.Field(tile.coord, "Coord");
				using (Cell.LineStd) Draw.Field(tile.distance, "Remoteness");
				using (Cell.LineStd) Draw.Field(tile.Priority, "Priority");
			}

			Cell.EmptyLinePx(4);

			using (Cell.LineStd) 
			{
				bool newMain = Draw.ToggleLeft(tile.main!=null, "Main");
				if (Cell.current.valChanged) 
				{
					if (newMain) { tile.main = new TerrainTile.DetailLevel(tile, isDraft:false); tile.StartGenerate(tile.mapMagic.graph); }
					else { tile.main.Remove(); tile.main=null; tile.SwitchLod(); }
					
				}
			}
			using (Cell.LineStd)
			{
				bool newDraft = Draw.ToggleLeft(tile.draft!=null, "Draft");
				if (Cell.current.valChanged) 
				{
					if (newDraft) { tile.draft = new TerrainTile.DetailLevel(tile, isDraft:true); tile.StartGenerate(tile.mapMagic.graph); }
					else { tile.draft.Remove(); tile.draft=null; tile.SwitchLod(); }
					
				}
			}

			Terrain activeTerrain = tile.ActiveTerrain;
			int currentLodNum = 0;
			if (activeTerrain != null  &&  tile.draft != null  &&  activeTerrain == tile.draft.terrain) currentLodNum = 1;
			if (activeTerrain != null  &&  tile.main != null  &&  activeTerrain == tile.main.terrain) currentLodNum = 2;
			using (Cell.LineStd) 
			{
				Draw.PopupSelector(ref currentLodNum, currentLodNames, "Current Detail");
				if (Cell.current.valChanged)
				{
					switch (currentLodNum)
					{
						case 1: tile.ActiveTerrain = tile.draft.terrain; break;
						case 2: tile.ActiveTerrain = tile.main.terrain; break;
						default: tile.ActiveTerrain = null; break;
					}
				}
			}


			Cell.EmptyLinePx(4);

			using (Cell.LineStd) 
			{
				bool newPreview = Draw.ToggleLeft(tile.mapMagic.PreviewTile == tile, "Selected for Preview");
				if (Cell.current.valChanged)
				{
					if (newPreview) tile.mapMagic.AssignPreviewTile(tile);
					else tile.mapMagic.ClearPreviewTile();
				}
			}

			using (Cell.LineStd) Draw.Toggle(tile.Ready, "Ready");

			float generateComplexity = tile.mapMagic.graph.GetGenerateComplexity();
			float applyComplexity = tile.mapMagic.graph.GetApplyComplexity();
			using (Cell.LineStd) Draw.DualLabel("Generate Complexity", generateComplexity.ToString());
			using (Cell.LineStd) Draw.DualLabel("Apply Complexity", applyComplexity.ToString());
			(float progress, float maxProgress) = tile.GetProgress(tile.mapMagic.graph, generateComplexity, applyComplexity);
			using (Cell.LineStd) Draw.DualLabel("Progress", progress.ToString() + " of " + maxProgress.ToString());
		}

	}//class

}//namespace