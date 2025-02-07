#region Copyright notice and license

// Copyright 2019 The gRPC Authors
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

#endregion


namespace Frontend.Balancer;

public class BalancerConfiguration
{
    public event EventHandler? Updated;

    public LoadBalancerName LoadBalancerPolicyName { get; private set; } = LoadBalancerName.PickFirst;

    public void Update(LoadBalancerName loadBalancerPolicyName)
    {
        LoadBalancerPolicyName = loadBalancerPolicyName;

        Updated?.Invoke(this, EventArgs.Empty);
    }
}

public enum LoadBalancerName
{
    RoundRobin,
    PickFirst
}
