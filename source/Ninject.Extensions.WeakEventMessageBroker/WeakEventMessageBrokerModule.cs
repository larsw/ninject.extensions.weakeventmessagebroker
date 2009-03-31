#region License

//
// Copyright � 2009 Ian Davis <ian.f.davis@gmail.com>
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//    http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

#endregion

#region Using Directives

using Ninject.Activation.Strategies;
using Ninject.Extensions.WeakEventMessageBroker;
using Ninject.Modules;
using Ninject.Planning.Strategies;

#endregion

namespace Ninject.Extensions.WeakEventMessageBroker
{
    public class WeakEventMessageBrokerModule : NinjectModule
    {
        /// <summary>
        /// Loads the module into the kernel.
        /// </summary>
        public override void Load()
        {
            Kernel.Components.Add<IPlanningStrategy, EventReflectionStrategy>();
            Kernel.Components.Add<IActivationStrategy, EventBindingStrategy>();
            Kernel.Components.Add<IWeakEventMessageBroker, WeakEventMessageBroker>();
        }

        /// <summary>
        /// Unloads the module from the kernel.
        /// </summary>
        public override void Unload()
        {
            Kernel.Components.RemoveAll<EventReflectionStrategy>();
            Kernel.Components.RemoveAll<EventBindingStrategy>();
            Kernel.Components.RemoveAll<IWeakEventMessageBroker>();
        }
    }
}