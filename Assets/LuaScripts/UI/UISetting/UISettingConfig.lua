--[[
-- added by author @ 2025/2/20 22:07:22
-- UISetting模块窗口配置，要使用还需要导出到UI.Config.UIConfig.lua
--]]
-- 窗口配置
local UISetting= {
	Name = UIWindowNames.UISetting,
	Layer = UILayers.SceneLayer,
	Model = require "UI.UISetting.Model.UISettingModel",
	Ctrl =  require "UI.UISetting.Controller.UISettingCtrl",
	View = require "UI.UISetting.View.UISettingView",
	PrefabPath = "UI/Prefabs/View/UISetting.prefab",
}


return {
	UISetting=UISetting,
}
