--busted should be required before hooking debugger to avoid double-hooking
require("busted.runner")()

if os.getenv("LOCAL_LUA_DEBUGGER_VSCODE") == "1" then
  require("lldebugger").start()
end

describe("a test", function()
  ...
end)