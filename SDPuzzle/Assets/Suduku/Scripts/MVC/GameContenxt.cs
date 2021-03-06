﻿using System;
using UnityEngine;
using strange.extensions.context.api;
using strange.extensions.context.impl;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.dispatcher.eventdispatcher.impl;

public class GameContext : MVCSContext
{

	public GameContext (MonoBehaviour view) : base(view)
	{
	}

	public GameContext (MonoBehaviour view, ContextStartupFlags flags) : base(view, flags)
	{
	}

	protected override void mapBindings()
	{
		//model
		injectionBinder.Bind<ILevel>().To<LevelModel>().ToSingleton(); //模型数据绑定为单例模式

		//view
		mediationBinder.Bind<MapLevelButton>().To<MapLevelMediator>();
		mediationBinder.Bind<Sudoku>().To<SudokuMediator>();
		mediationBinder.Bind<WinView>().To<WinMediator>();
		//command
		commandBinder.Bind(GameEvent.LOAD_SCENE).To<LoadSceneCommand>();
		commandBinder.Bind (GameEvent.GAME_OVER).To<GameOverCommand> ();
		commandBinder.Bind(ContextEvent.START).To<StartSdkCommand>().To<StartAppCommand>().Once().InSequence();;

	}
}